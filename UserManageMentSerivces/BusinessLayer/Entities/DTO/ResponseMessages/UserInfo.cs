﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManageMentSerivces.BusinessLayer.DTO
{
    public class UserInfo
    {
        public string UserEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserStatus { get; set; }
        public string UserType { get; set; }
    }
}