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
using LightInject;

namespace UserManageMentSerivces.BusinessLayer
{
    public class GetUserDetails : IGetUserDetailsServices
    {
        private static GetUserDetails _instance;
        public static GetUserDetails Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new GetUserDetails();
                    }
                }
                return _instance;
            }
        }
        public async Task<List<UserInformation>> GetUserInformation(UserLoginRequestMessages user)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserLoginRequestMessages, UserLoginRequestDTO>()
            );
            DAOConfig daoConfig = new DAOConfig();
            BusinessLoginUserResponse userResponse = new BusinessLoginUserResponse();
            UserLoginRequestDTO requestMessage = new UserLoginRequestDTO();
            requestMessage = config.CreateMapper().Map<UserLoginRequestDTO>(user);
            var userInformation = daoConfig.container.GetInstance<IGetUserLoginAuthenticate>();
            var userInfo = await userInformation.GetAllUserInformations(requestMessage);
            //List<UserInformation> userInfo = await DAOServiceManager.GetInstance().GetUserInformationAll().GetAllUserInformations(requestMessage);

            if (userInfo != null)
            {
                return userInfo;
            }
            return null;
        }
    }
}
