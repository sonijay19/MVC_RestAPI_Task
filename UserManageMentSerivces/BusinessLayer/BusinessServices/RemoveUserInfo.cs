using RESTServices.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Interfaces;

namespace UserManageMentSerivces.BusinessLayer.BusinessServices
{
    public class RemoveUserInfo : IUserDetailsRemoveService
    {
        private static RemoveUserInfo _instance;
        public static RemoveUserInfo Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new RemoveUserInfo();
                    }
                }
                return _instance;
            }
        }
        public async Task<bool> DeleteUserInformation(string userId)
        {
            var userInfo = await DAOServiceManager.GetInstance().DeleteUserInformation().
                DeleteUserDetailsAsync(userId);
            if (userInfo)
            {
                return userInfo;
            }
            return false;
        }
    }
}
