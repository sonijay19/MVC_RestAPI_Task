using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer.RequestMessages;

namespace UserManageMentSerivces.BusinessLayer.Interfaces
{
    public interface IUserUpdateInformationServices
    {
        Task<bool> BusinessUpdateUserInformation(UserUpdateRequestMessage user);
    }
}
