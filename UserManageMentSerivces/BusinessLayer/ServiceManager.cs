using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.BusinessServices;
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

        //BusinessUpdateUserInformation
        public IUserUpdateInformationServices UserDetailsUpdate()
        {
            return BusinessUserUpdateInformation.Instance;
        }

        public IUserDetailsRemoveService DeleteUserDetails()
        {
            return RemoveUserInfo.Instance;
        }
    }
}
