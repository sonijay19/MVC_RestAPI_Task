using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.DAO.Interface;
using UserManageMentSerivces.BusinessLayer.Entities.DTO;
using UserManageMentSerivces.DAO;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.DAO.propeties;

namespace UserManageMentSerivces.DAO
{

    public class GetUserInformationDB : IGetUserLoginAuthenticate
    {
        private SqlConnection conn;
        public GetUserInformationDB()
        {
            ConnectionDB connect = new ConnectionDB();
            this.conn = connect.ConnectDb();
        }

        private static GetUserInformationDB _instance;
        public static GetUserInformationDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new GetUserInformationDB();
                    }
                }
                return _instance;
            }
        }

        public static string GetEmailQuery(string userEmail)
        {
            return $"UserDetails.UserEmail = @userEmail AND";
        }

        async Task<UserInformation> IGetUserLoginAuthenticate.GetUserAuthenticate(UserLoginRequestDTO UserDetails)
        {
            UserInformation UserInfo = new UserInformation();
            GetQueryByProperties getQuery = new GetQueryByProperties();
            string query = getQuery.GetDetailQuery("AuthenticateUser", "LoginAuthenticate");
            string newQuery = query.Replace("{useremail}", GetEmailQuery(UserDetails.UserEmail));
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(newQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userEmail", UserDetails.UserEmail);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        UserInfo =
                            new UserInformation
                            {
                                UserEmail = reader["UserEmail"].ToString(),
                                FirstName = reader["firstName"].ToString(),
                                LastName = reader["lastName"].ToString(),
                                UserType = ((UserIdDeleted)Convert.ToInt16(reader["IsDeleted"])).ToString(),
                                UserStatus = reader["StatusCode"].ToString(),
                            };
                    }
                    conn.Close();
                    return UserInfo;
                }
            }
        }

        async Task<List<UserInformation>> IGetUserLoginAuthenticate.GetAllUserInformations(UserLoginRequestDTO UserEmail)
        {
            List<UserInformation> UserInfo = new List<UserInformation>();
            GetQueryByProperties getQuery = new GetQueryByProperties();
            string query = getQuery.GetDetailQuery("AuthenticateUser", "LoginAuthenticate");
            string newQuery = query.Replace("{useremail}", "");
            using (SqlCommand cmd = new SqlCommand(newQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {

                    while (reader.Read())
                    {
                        UserInfo.Add(
                            new UserInformation
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserEmail = reader["UserEmail"].ToString(),
                                FirstName = reader["firstName"].ToString(),
                                LastName = reader["lastName"].ToString(),
                                UserType = ((UserIdDeleted)Convert.ToInt16(reader["IsDeleted"])).ToString(),
                                UserStatus = reader["StatusCode"].ToString(),
                            }
                        );
                    }
                    conn.Close();
                    return UserInfo;
                }
            }
        }
    }
}
