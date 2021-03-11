using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using UserManageMentSerivces.DAO.Interface;

namespace UserManageMentSerivces.BusinessLayer.BusinessServices
{
    public class RemoveUserInfo : IUserDetailsRemoveService
    {
        private static IDeleteUserDetails deleteUser;
        public RemoveUserInfo(IDeleteUserDetails deleteUserDetails)
        {
            deleteUser = deleteUserDetails;
        }
        public async Task<bool> DeleteUserInformation(string userId)
        {
            var userInfo = await deleteUser.DeleteUserDetailsAsync(userId);
            if (userInfo)
            {
                return userInfo;
            }
            return false;
        }
    }
}
