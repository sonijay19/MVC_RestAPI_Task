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
    [Route("api/v1/LoginUser")]
    public class UserLoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(UserLoginRequestMessages request)
        {
            RequestProcessor client = new RequestProcessor();
            var response = await client.AuthenticateUser(request);
            return Ok(response);
        }
    }
}
