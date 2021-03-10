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
    public class GetUserDetails : IGetUserDetailsServices
    {
        private readonly IGetUserLoginAuthenticate userAuthenticate;
        public GetUserDetails(IGetUserLoginAuthenticate userAuthenticate)
        {
            this.userAuthenticate = userAuthenticate;
        }
        public async Task<List<UserInformation>> GetUserInformation(UserLoginRequestMessages user)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserLoginRequestMessages, UserLoginRequestDTO>()
            );
            DAOConfig daoConfig = new DAOConfig();
            BusinessLoginUserResponse userResponse = new BusinessLoginUserResponse();
            UserLoginRequestDTO requestMessage = new UserLoginRequestDTO();
            var userInfo = await userAuthenticate.GetAllUserInformations(requestMessage);
            //List<UserInformation> userInfo = await DAOServiceManager.GetInstance().GetUserInformationAll().GetAllUserInformations(requestMessage);

            if (userInfo != null)
            {
                return userInfo;
            }
            return null;
        }
    }
}
