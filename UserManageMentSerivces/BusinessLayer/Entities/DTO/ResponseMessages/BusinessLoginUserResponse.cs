using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManageMentSerivces.BusinessLayer.Entities.DTO
{
    public class BusinessLoginUserResponse
    {
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserStatus { get; set; }
        public string UserType { get; set; }
    }
}
