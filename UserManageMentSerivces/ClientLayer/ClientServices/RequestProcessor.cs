using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.ClientLayer.ResponseMessages;
using UserManageMentSerivces.ClientLayer.Validation;
using UserManageMentSerivces.BusinessLayer;
using AutoMapper;
using UserManageMentSerivces.BusinessLayer.Entities.DTO;
using UserManageMentSerivces.Exceptions;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.DAO;

namespace DemoService.ClientLayer
{
    public class RequestProcessor
    {
        private static RequestProcessor _instance;
        public static RequestProcessor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RequestProcessor();
                }
                return _instance;
            }
        }
        public async Task<UserLoginResponseMessages> AuthenticateUser(UserLoginRequestMessages userDetails)
        {
            UserLoginResponseMessages responseUser = new UserLoginResponseMessages();
            try
            {
                LoginUserValidation validator = new LoginUserValidation();
                var result = validator.Validate(userDetails);
                if (result.IsValid)
                {
                    var UserInfo = await ServiceManager.GetInstance().GetUserLoginAuthentication()
                        .AuthenticateUser(userDetails);
                    if(UserInfo.UserEmail is null)
                    {
                        throw new UserLoginException(ErrorCodes.USER_NOT_FOUND);
                    }
                    responseUser.UserDetails = UserInfo;
                    return responseUser;
                }
                throw new UserLoginException(ErrorCodes.ERROR_FROM_VALIDATE);
            }
            catch (UserLoginException e)
            {
                responseUser.ErrorCodes = e._errorConstants.ToString();
                return responseUser;
            }
        }

        public async Task<GetUserDetailsResponseMessage> GetUserInformationAsync(UserLoginRequestMessages userDetails)
        {
            GetUserDetailsResponseMessage responseUser = new GetUserDetailsResponseMessage();
            try
            {
                LoginUserValidation validator = new LoginUserValidation();
                var result = validator.Validate(userDetails);
                if (result.IsValid)
                {
                    var UserInfo = await ServiceManager.GetInstance().GetAllUserDetails()
                        .GetUserInformation(userDetails);
                    if (UserInfo[0].UserEmail is null)
                    {
                        throw new UserLoginException(ErrorCodes.USER_NOT_FOUND);
                    }
                    responseUser.Total_Count = UserInfo.Count;
                    responseUser.UserDetails = UserInfo;
                    return responseUser;
                }
                throw new UserLoginException(ErrorCodes.ERROR_FROM_VALIDATE);
            }
            catch (UserLoginException e)
            {
                responseUser.ErrorCodes = e._errorConstants.ToString();
                return responseUser;
            }
        }
    }
}