using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.DAO;
using UserManageMentSerivces.DAO.DAOServices;
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

        public IUserDetailsUpdate UpdateUserInformation()
        {
            return UserUpdateDetails.Instance;
        }

        public IUserDetailsInsert InsertUserDetails()
        {
            return InsertUserDetailsServices.Instance;
        }
        // DeleteUserDetailsService IDeleteUserDetails
        public IDeleteUserDetails DeleteUserInformation()
        {
            return DeleteUserDetailsService.Instance;
        }
    }
}
