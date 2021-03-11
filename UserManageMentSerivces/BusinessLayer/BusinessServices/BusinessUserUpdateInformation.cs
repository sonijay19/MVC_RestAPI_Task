using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.DTO.ReuestMessages;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using LightInject;
using UserManageMentSerivces.DAO.Interface;

namespace UserManageMentSerivces.BusinessLayer.BusinessServices
{
    public class BusinessUserUpdateInformation : IUserUpdateInformationServices
    {

        private static IUserDetailsUpdate userUpdateInformation;
        public BusinessUserUpdateInformation(IUserDetailsUpdate businessUserUpdateInformation)
        {
            userUpdateInformation = businessUserUpdateInformation;
        }

        public async Task<bool> BusinessUpdateUserInformation(UserUpdateRequestMessage userDetails)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserUpdateRequestMessage, BusinessUpdateUserRequestMessage>()
            );
            var requestMessage = config.CreateMapper().Map<BusinessUpdateUserRequestMessage>(userDetails);
            /*var userInfo = await DAOServiceManager.GetInstance().UpdateUserInformation()
                .UpdateUserDetailAsync(requestMessage);*/
            var userInfo = await userUpdateInformation.UpdateUserDetailAsync(requestMessage);
            if (userInfo)
            {
                return userInfo;
            }
            return false;
        }
    }
}
