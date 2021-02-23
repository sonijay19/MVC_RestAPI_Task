using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer.ClientServices;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;

namespace UserManageMentSerivces.ClientLayer
{
    public class ClientServiceManager
    {
        private static ClientServiceManager clientServiceManagerInstance = new ClientServiceManager();
        public static ClientServiceManager GetInstance()
        {

            return clientServiceManagerInstance;
        }

        public IClientUserUpdateServices UpdateUserInformation()
        {
            return ClientUpdateUserService.Instance;
        }
    }
}
