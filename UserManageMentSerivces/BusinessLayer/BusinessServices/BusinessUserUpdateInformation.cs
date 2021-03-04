using AutoMapper;
using RESTServices.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.DTO.ReuestMessages;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using LightInject;

namespace UserManageMentSerivces.BusinessLayer.BusinessServices
{
    public class BusinessUserUpdateInformation : IUserUpdateInformationServices
    {
        private static BusinessUserUpdateInformation _instance;
        public static BusinessUserUpdateInformation Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new BusinessUserUpdateInformation();
                    }
                }
                return _instance;
            }
        }

        public async Task<bool> BusinessUpdateUserInformation(UserUpdateRequestMessage userDetails)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserUpdateRequestMessage, BusinessUpdateUserRequestMessage>()
            );
            var requestMessage = config.CreateMapper().Map<BusinessUpdateUserRequestMessage>(userDetails);
            var userInfo = await DAOServiceManager.GetInstance().UpdateUserInformation()
                .UpdateUserDetailAsync(requestMessage);
            if (userInfo)
            {
                return userInfo;
            }
            return false;
        }
    }
}
