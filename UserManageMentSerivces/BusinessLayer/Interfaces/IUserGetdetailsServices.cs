using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.DTO;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.DAO;

namespace UserManageMentSerivces.BusinessLayer.Interfaces
{
    public interface IUserGetdetailsServices
    {
        Task<UserInformation> AuthenticateUser(UserLoginRequestMessages user);
    }
}
