using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.DAO.DAOServices;
using UserManageMentSerivces.DAO.Interface;

namespace UserManageMentSerivces.DAO
{
    public class DAOConfig
    {
        public ServiceContainer container = new ServiceContainer();
        public DAOConfig()
        {
            //container.Register<IGetUserLoginAuthenticate, GetUserInformationDB>();
            //InsertUserDetailsServices: IUserDetailsInsert
            container.Register<IUserDetailsInsert, InsertUserDetailsServices>();
        }
    }
}
