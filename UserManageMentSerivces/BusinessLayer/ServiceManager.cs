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

        public IUserGetdetailsServices GetUserLoginAuthentication()
        {
            return AuthenticateUser.Instance;
        }

        public IGetUserDetailsServices GetAllUserDetails()
        {
            return GetUserDetails.Instance;
        }

        //BusinessUpdateUserInformation
        public IUserUpdateInformationServices UserDetailsUpdate()
        {
            return BusinessUserUpdateInformation.Instance;
        }

        public IBusinessInsertUserDetails InsertUserInformation()
        {
            return BusinessInsertUserDetails.Instance;
        }

        public IUserDetailsRemoveService DeleteUserDetails()
        {
            return RemoveUserInfo.Instance;
        }
    }
}
