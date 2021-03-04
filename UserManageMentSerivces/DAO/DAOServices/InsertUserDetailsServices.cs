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
    public class InsertUserDetailsServices : IUserDetailsInsert
    {
        private SqlConnection conn;

        public InsertUserDetailsServices()
        {
            ConnectionDB connect = new ConnectionDB();
            this.conn = connect.ConnectDb();
        }
        private static InsertUserDetailsServices _instance;
        public static InsertUserDetailsServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new InsertUserDetailsServices();
                    }
                }
                return _instance;
            }
        }
        public async Task<bool> InsertUserDetails(BusinessInsertUserRequestMessage UserDetails)
        {
            // updatedUserEmail updatedUserFirstName updatedUserLastName updatedUserTypeId userId
            GetQueryByProperties getQuery = new GetQueryByProperties();
            string query = getQuery.GetDetailQuery("InsertOne", "InsertOneNew");
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                //@phonenumber
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.AddWithValue("@userid", Convert.ToInt16(UserDetails.UserId));
                cmd.Parameters.AddWithValue("@userTypeId", (int)Enum.Parse(typeof(UserAccessType),UserDetails.UserStatus)+1);
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
                        AddNewUserServices services = new AddNewUserServices(new ActiveUser());
                        if (await services.InsertQuery(UserDetails))
                        {
                            conn.Close();
                            return true;
                        }
                        conn.Close();
                        return false;
                    }
                    else
                    {
                        AddNewUserServices services = new AddNewUserServices(new AddNewUser());
                        if(await services.InsertQuery(UserDetails))
                        {
                            conn.Close();
                            return true;
                        }
                        conn.Close();
                        return false;
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
}
