using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManageMentSerivces.DAO.Interface
{
    public interface IDeleteUserDetails
    {
        Task<bool> DeleteUserDetailsAsync(string userId);
    }
}
