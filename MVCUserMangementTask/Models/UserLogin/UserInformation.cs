using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCUserMangementTask.Controllers.ResponseMessages
{
    public class UserInformation
    {
        public string UserEmail { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserStatus { get; set; }
        public string UserType { get; set; }
    }
}
