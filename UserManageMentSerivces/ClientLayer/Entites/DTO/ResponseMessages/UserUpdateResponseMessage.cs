using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;

namespace UserManageMentSerivces.ClientLayer.ResponseMessages
{
    public class UserUpdateResponseMessage
    {
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
    }
}
