using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCUserMangementTask.Models.UserLogin
{
    public class UserRequestModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Email Address")]
        public string UserEmail { get; set; }
    }
}
