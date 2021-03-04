using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManageMentSerivces.BusinessLayer.Entities.DTO.ReuestMessages
{
    public class BusinessInsertUserRequestMessage
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string PhoneNumber { get; set; }
        public string UserStatus { get; set; }
    }
}
