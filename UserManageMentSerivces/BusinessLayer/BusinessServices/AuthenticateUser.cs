using AutoMapper;
using RESTServices.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.DTO;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.DAO;

namespace UserManageMentSerivces.BusinessLayer
{
    public class AuthenticateUser : IUserGetdetailsServices
    {
        private static AuthenticateUser _instance;
        public static AuthenticateUser Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new AuthenticateUser();
                    }
                }
                return _instance;
            }
        }

        async Task<UserInformation> IUserGetdetailsServices.AuthenticateUser(UserLoginRequestMessages user)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserLoginRequestMessages, UserLoginRequestDTO>()
            );
            BusinessLoginUserResponse userResponse = new BusinessLoginUserResponse();
            UserLoginRequestDTO requestMessage = new UserLoginRequestDTO();
            requestMessage = config.CreateMapper().Map<UserLoginRequestDTO>(user);

            var userInfo = await DAOServiceManager.GetInstance().GetAuthenticateUserByEmail()
                .GetUserAuthenticate(requestMessage);
            if (userInfo != null)
            {
                return userInfo;
            }
            return null;
        }
    }
}
