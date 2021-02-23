using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.DAO.Interface;

namespace UserManageMentSerivces.DAO.DAOServices
{
    public class UserUpdateDetails : IUserDetailsUpdate
    {
        public Task<bool> UpdateUserDetail(UserInformation user)
        {
            throw new NotImplementedException();
        }
    }
}
