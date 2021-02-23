using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.ClientLayer.ResponseMessages;

namespace UserManageMentSerivces.ClientLayer.ClientServices
{
    public class ClientUpdateUserService : IClientUserUpdateServices
    {
        private static ClientUpdateUserService _instance;
        public static ClientUpdateUserService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientUpdateUserService();
                }
                return _instance;
            }
        }

        async public Task<UserUpdateResponseMessage> UpdateUserDetailsAsync(UserUpdateRequestMessage user)
        {
            throw new NotImplementedException();
        }
    }
}
