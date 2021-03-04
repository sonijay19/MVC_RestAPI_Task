using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManageMentSerivces.ClientLayer
{
    public class ClientConfig
    {
        public ServiceContainer container = new ServiceContainer();
        public ClientConfig()
        {
            //container.Register<>();
        }
    }
}
