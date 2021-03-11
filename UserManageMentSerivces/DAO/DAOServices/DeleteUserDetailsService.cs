using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.DAO.Interface;
using UserManageMentSerivces.DAO.propeties;

namespace UserManageMentSerivces.DAO.DAOServices
{
    public class DeleteUserDetailsService : IDeleteUserDetails
    {
        private SqlConnection conn;

        public DeleteUserDetailsService()
        {
            ConnectionDB connect = new ConnectionDB();
            this.conn = connect.ConnectDb();
        }
        public async Task<bool> DeleteUserDetailsAsync(string userId)
        {
            // updatedUserEmail updatedUserFirstName updatedUserLastName updatedUserTypeId userId
            GetQueryByProperties getQuery = new GetQueryByProperties();
            string query = getQuery.GetDetailQuery("DeleteUserDetail", "DeleteUserInformation");
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                //@phonenumber
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.AddWithValue("@userid", Convert.ToInt16(userId));
                
                try
                {
                    int result = await cmd.ExecuteNonQueryAsync();
                    if (result != 1)
                    {
                        conn.Close();
                        return false;
                    }
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
