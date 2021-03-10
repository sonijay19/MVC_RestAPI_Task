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
using UserManageMentSerivces.DAO.Interface;

namespace UserManageMentSerivces.BusinessLayer
{
    public class AuthenticateUser : IUserGetdetailsServices
    {
        private IGetUserLoginAuthenticate userAuthenticate;
        public AuthenticateUser(IGetUserLoginAuthenticate userAuthenticate)
        {
            this.userAuthenticate = userAuthenticate;
        }

        public async Task<UserInformation> AuthenticateUserAsync(UserLoginRequestMessages user)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserLoginRequestMessages, UserLoginRequestDTO>()
            );
            BusinessLoginUserResponse userResponse = new BusinessLoginUserResponse();
            UserLoginRequestDTO requestMessage = new UserLoginRequestDTO();
            requestMessage = config.CreateMapper().Map<UserLoginRequestDTO>(user);
            var userInfo = await userAuthenticate.GetUserAuthenticate(requestMessage);
            /*var userInfo = await DAOServiceManager.GetInstance().GetAuthenticateUserByEmail()
                .GetUserAuthenticate(requestMessage);*/
            if (userInfo != null)
            {
                return userInfo;
            }
            return null;
        }
    }
}
