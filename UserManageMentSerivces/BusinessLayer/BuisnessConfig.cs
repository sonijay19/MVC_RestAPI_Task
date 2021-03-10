using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LightInject;
using UserManageMentSerivces.BusinessLayer.BusinessServices;
using UserManageMentSerivces.BusinessLayer.Interfaces;

namespace UserManageMentSerivces.BusinessLayer
{
    public class BuisnessConfig
    {
        public ServiceContainer container = new ServiceContainer();
        public BuisnessConfig()
        {
            //container.Register<IGetUserDetailsServices, GetUserDetails>();
            //BusinessInsertUserDetails : IBusinessInsertUserDetails
            container.Register<IBusinessInsertUserDetails,BusinessInsertUserDetails>();
        }
    }
}
