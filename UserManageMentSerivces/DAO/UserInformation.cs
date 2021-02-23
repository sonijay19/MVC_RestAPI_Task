using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace UserManageMentSerivces.DAO
{
    public class UserInformation
    {
        public int? UserId { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserStatus { get; set; }
        public string UserType { get; set; }
    }
}
