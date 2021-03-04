using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.DTO.ReuestMessages;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.DAO.Interface;
using UserManageMentSerivces.DAO.propeties;
using UserManageMentSerivces.Exceptions;

namespace UserManageMentSerivces.DAO.DAOServices
{
    public class UserUpdateDetails : IUserDetailsUpdate
    {
        private SqlConnection conn;

        public UserUpdateDetails()
        {
            ConnectionDB connect = new ConnectionDB();
            this.conn = connect.ConnectDb();
        }
        private static UserUpdateDetails _instance;
        public static UserUpdateDetails Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new UserUpdateDetails();
                    }
                }
                return _instance;
            }
        }
        async Task<bool> IUserDetailsUpdate.UpdateUserDetailAsync(BusinessUpdateUserRequestMessage UserDetails)
        {
            // updatedUserEmail updatedUserFirstName updatedUserLastName updatedUserTypeId userId
            GetQueryByProperties getQuery = new GetQueryByProperties();
            string query = getQuery.GetDetailQuery("UpdateUserDetails", "UpdateUserInformation");
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                //@phonenumber
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.AddWithValue("@userId", Convert.ToInt16(UserDetails.UserId));
                cmd.Parameters.AddWithValue("@updatedUserTypeId", (int)Enum.Parse(typeof(UserAccessType),UserDetails.userStatus)+1);
                cmd.Parameters.AddWithValue("@updatedUserFirstName", UserDetails.FirstName);
                cmd.Parameters.AddWithValue("@updatedUserLastName", UserDetails.LastName);
                cmd.Parameters.AddWithValue("@updatedUserEmail", UserDetails.UserEmail);
                cmd.Parameters.AddWithValue("@phonenumber", UserDetails.PhoneNumber);
                try
                {
                    int result = await cmd.ExecuteNonQueryAsync();
                    if(result != 1)
                    {
                        conn.Close();
                        return false;
                    }
                    conn.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    conn.Close();
                    return false;
                }
            }
        }
    }
}
