using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.DAO;

namespace UserManageMentSerivces.BusinessLayer.Interfaces
{
    public interface IBusinessInsertUserDetails
    {
        Task<bool> InsertUserDetails(UserUpdateRequestMessage user);
    }
}
