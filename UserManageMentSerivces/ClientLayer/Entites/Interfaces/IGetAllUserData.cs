using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.ClientLayer.ResponseMessages;

namespace UserManageMentSerivces.ClientLayer.Entites.Interfaces
{
    interface IGetAllUserData
    {
        Task<GetUserDetailsResponseMessage> GetUserInformationAsync(UserLoginRequestMessages userDetails);
    }
}
