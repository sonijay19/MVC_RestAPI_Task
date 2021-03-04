using DemoService.ClientLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer.RequestMessages;

namespace UserManageMentSerivces.Controllers
{
    [ApiController]
    [Route("api/v1/GetUserDetails")]
    public class GetUserDetailsController : ControllerBase
    {
        [HttpGet]   
        public async Task<IActionResult> Get()
        {
            //soni1@gmail.com
            RequestProcessor client = new RequestProcessor();
            UserLoginRequestMessages request = new UserLoginRequestMessages();
            request.UserEmail = "soni1@gmail.com";
            var response = await client.GetUserInformationAsync(request);
            return Ok(response);
        }
    }
}
