using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManageMentSerivces.BusinessLayer.Interfaces
{
    public interface IUserDetailsRemoveService
    {
        Task<bool> DeleteUserInformation(string userId);
    }
}
