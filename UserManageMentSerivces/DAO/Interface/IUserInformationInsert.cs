using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.ClientLayer.ResponseMessages;

namespace UserManageMentSerivces.DAO.Interface
{
    public interface IUserInformationInsert
    {
        Task<UserUpdateResponseMessage> InsertUserDetailsAsync(UserUpdateRequestMessage userDetails);
    }
}
