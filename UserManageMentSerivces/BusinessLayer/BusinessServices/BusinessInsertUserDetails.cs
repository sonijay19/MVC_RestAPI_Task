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
        private static BusinessInsertUserDetails _instance;
        public static BusinessInsertUserDetails Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new BusinessInsertUserDetails();
                    }
                }
                return _instance;
            }
        }
        public async Task<bool> InsertUserDetails(UserUpdateRequestMessage user)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserUpdateRequestMessage, BusinessInsertUserRequestMessage>()
            );
            var requestMessage = config.CreateMapper().Map<BusinessInsertUserRequestMessage>(user);
            DAOConfig daoConfig = new DAOConfig();
            var obj = daoConfig.container.GetInstance<IUserDetailsInsert>();
            /*var instance = new BuisnessConfig();
            var obj = instance.container.GetInstance<IBusinessInsertUserDetails>();*/
            var userInfo = await obj.InsertUserDetails(requestMessage);
            /*var userInfo = await DAOServiceManager.GetInstance().InsertUserDetails()
                .InsertUserDetails(requestMessage);*/
            if (userInfo)
            {
                return userInfo;
            }
            return false;
        }
    }
}
