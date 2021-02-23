using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.DAO;
using UserManageMentSerivces.DAO.Interface;

namespace RESTServices.DAO
{
    public class DAOServiceManager
    {
        private static DAOServiceManager daoserviceManagerInstance = new DAOServiceManager();

        public static DAOServiceManager GetInstance()
        {
            return daoserviceManagerInstance;
        }

        public IGetUserLoginAuthenticate GetAuthenticateUserByEmail()
        {
            return GetUserInformationDB.Instance;
        }

        public IGetUserLoginAuthenticate GetUserInformationAll()
        {
            return GetUserInformationDB.Instance;
        }
    }
}
