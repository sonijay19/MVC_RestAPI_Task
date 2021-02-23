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
        async Task<List<UserInformation>> IGetUserDetailsServices.GetUserInformation(UserLoginRequestMessages user)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserLoginRequestMessages, UserLoginRequestDTO>()
            );

            BusinessLoginUserResponse userResponse = new BusinessLoginUserResponse();
            UserLoginRequestDTO requestMessage = new UserLoginRequestDTO();
            requestMessage = config.CreateMapper().Map<UserLoginRequestDTO>(user);
            List<UserInformation> userInfo = await DAOServiceManager.GetInstance().GetUserInformationAll().GetAllUserInformations(requestMessage);

            if (userInfo != null)
            {
                return userInfo;
            }
            return null;
        }
    }
}
