using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Interfaces;

namespace UserManageMentSerivces.BusinessLayer
{
    public class ServiceManager
    {
        private static ServiceManager serviceManagerInstance = new ServiceManager();
        public static ServiceManager GetInstance()
        {

            return serviceManagerInstance;
        }

        public IUserGetdetailsServices GetUserLoginAuthentication()
        {
            return AuthenticateUser.Instance;
        }

        public IGetUserDetailsServices GetAllUserDetails()
        {
            return GetUserDetails.Instance;
        }
    }
}
