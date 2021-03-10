using AutoMapper;
using RESTServices.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.DTO.ReuestMessages;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.DAO;
using LightInject;
using UserManageMentSerivces.DAO.Interface;

namespace UserManageMentSerivces.BusinessLayer.BusinessServices
{
    public class BusinessInsertUserDetails : IBusinessInsertUserDetails
    {
        
        private IUserDetailsInsert userDetailsInsert;
        public BusinessInsertUserDetails(IUserDetailsInsert detailsInsert)
        {
            userDetailsInsert = detailsInsert;
        }

        public async Task<bool> InsertUserDetails(UserUpdateRequestMessage user)
        {
            
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserUpdateRequestMessage, BusinessInsertUserRequestMessage>()
            );

            var requestMessage = config.CreateMapper().Map<BusinessInsertUserRequestMessage>(user);
            var userInfo = await userDetailsInsert.InsertUserDetails(requestMessage);
            if (userInfo)
            {
                return userInfo;
            }
            return false;
        }
    }
}
