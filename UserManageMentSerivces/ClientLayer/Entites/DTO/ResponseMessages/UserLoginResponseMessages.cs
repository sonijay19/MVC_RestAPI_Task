using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.DAO;

namespace UserManageMentSerivces.ClientLayer.ResponseMessages
{
    public class UserLoginResponseMessages
    {
        public UserInformation? UserDetails { get; set; }
        public string? ErrorCodes { get; set; }
    }
}
