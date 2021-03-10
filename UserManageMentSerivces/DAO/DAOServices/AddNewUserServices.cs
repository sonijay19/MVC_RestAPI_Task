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

namespace UserManageMentSerivces.DAO.DAOServices
{
    public class AddNewUser : IInsertUserInformationAdd
    {
        private SqlConnection conn;

        public AddNewUser()
        {
            ConnectionDB connect = new ConnectionDB();
            this.conn = connect.ConnectDb();
        }
        public async Task<bool> InsertQuery(BusinessInsertUserRequestMessage UserDetails)
        {
            GetQueryByProperties getQuery = new GetQueryByProperties();
            string query = getQuery.GetDetailQuery("InsertUserDetail", "AddUserDetail");
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                //@phonenumber
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.AddWithValue("@userid", Convert.ToInt16(UserDetails.UserId));
                cmd.Parameters.AddWithValue("@userTypeId", (int)Enum.Parse(typeof(UserAccessType), UserDetails.UserStatus) + 1);
                cmd.Parameters.AddWithValue("@firstname", UserDetails.FirstName.ToString());
                cmd.Parameters.AddWithValue("@lastname", UserDetails.LastName.ToString());
                cmd.Parameters.AddWithValue("@useremail", UserDetails.UserEmail.ToString());
                cmd.Parameters.AddWithValue("@phonenumber", UserDetails.PhoneNumber.ToString());
                try
                {
                    var reader = await cmd.ExecuteReaderAsync();
                    var one = reader.Read();
                    if (one)
                    {

                        conn.Close();
                        return true;
                    }
                    /*while (reader.Read())
                    {
                        Debug.WriteLine(reader[0]);
                    }*/
                    /*if (result == -1)
                    {
                        conn.Close();
                        return false;
                    }*/
                    conn.Close();
                    return false;
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
    public class ActiveUser : IInsertUserInformationAdd
    {
        private SqlConnection conn;

        public ActiveUser()
        {
            ConnectionDB connect = new ConnectionDB();
            this.conn = connect.ConnectDb();
        }
        public async Task<bool> InsertQuery(BusinessInsertUserRequestMessage UserDetails)
        {
            GetQueryByProperties getQuery = new GetQueryByProperties();
            //string newQuery = "SELECT * FROM UserDetails WHERE UserEmail = 'soni993@gmail.com' AND PhoneNumber = '3653658625' AND FirstName = 'asdf' AND LastName = 'asdfj'";
            string query = getQuery.GetDetailQuery("UpdateStatus", "ChangeStatus");
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                //@phonenumber
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.AddWithValue("@useremail", UserDetails.UserEmail.ToString());
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
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    conn.Close();
                    return false;
                }
            }
        }
    }
    public class AddNewUserServices
    {
        private IInsertUserInformationAdd insertUserInformationAdd;
        public AddNewUserServices(IInsertUserInformationAdd strategy)
        {
            insertUserInformationAdd = strategy;
        }

        public Task<bool> InsertQuery(BusinessInsertUserRequestMessage userDetails)
        {
            return insertUserInformationAdd.InsertQuery(userDetails);
        }
    }
}
