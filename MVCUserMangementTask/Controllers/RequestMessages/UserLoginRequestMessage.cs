using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCUserMangementTask.Controllers.RequestMessages
{
    public class UserLoginRequestMessage
    {
        [Required(ErrorMessage = "Please enter your message")]
        [Display(Name ="*useremail")]
        [DataType(DataType.Text)]
        public string UserEmail { get; set; }
    }
}
