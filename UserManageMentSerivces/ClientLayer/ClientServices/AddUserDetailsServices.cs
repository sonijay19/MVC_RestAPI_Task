using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.ClientLayer.Entites.Validation;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.ClientLayer.ResponseMessages;
using UserManageMentSerivces.DAO.Interface;
using UserManageMentSerivces.Exceptions;
using LightInject;
using UserManageMentSerivces.BusinessLayer.Interfaces;

namespace UserManageMentSerivces.DAO.DAOServices
{
    public class AddUserDetailsServices : IUserInformationInsert
    {
        private static AddUserDetailsServices _instance;
        public static AddUserDetailsServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AddUserDetailsServices();
                }
                return _instance;
            }
        }
        public async Task<UserUpdateResponseMessage> InsertUserDetailsAsync(UserUpdateRequestMessage userDetails)
        {
            UserUpdateResponseMessage responseUser = new UserUpdateResponseMessage();
            try
            {
                UserInformationValidation validator = new UserInformationValidation();
                var result = validator.Validate(userDetails);
                if (result.IsValid)
                {
                    var instance = new BuisnessConfig();
                    var obj = instance.container.GetInstance<IBusinessInsertUserDetails>();
                    var UserInfo = await obj.InsertUserDetails(userDetails);
                    /*var UserInfo = await ServiceManager.GetInstance().InsertUserInformation()
                        .InsertUserDetails(userDetails);*/
                    if (UserInfo)
                    {
                        responseUser.Success = UserInfo;
                        return responseUser;
                    }
                    throw new UpdateUserDetailsExceptions(ErrorCodes.USER_NOT_FOUND);
                }
                throw new UpdateUserDetailsExceptions(ErrorCodes.ERROR_FROM_VALIDATE);
            }
            catch (UpdateUserDetailsExceptions e)
            {
                responseUser.ErrorCode = e._errorConstants.ToString();
                return responseUser;
            }
        }
    }
}
