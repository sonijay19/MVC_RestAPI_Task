using MVCUserMangementTask.Controllers.ResponseMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCUserMangementTask.Controllers
{
    public class LoginUserResponseMessages
    {
        public UserInformation? UserDetails { get; set; }
        public string? ErrorCodes { get; set; }
    }
}
