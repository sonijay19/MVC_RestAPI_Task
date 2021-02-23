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
        public async Task<IActionResult> Get(UserLoginRequestMessages request)
        {
            RequestProcessor client = new RequestProcessor();
            var response = await client.GetUserInformationAsync(request);
            return Ok(response);
        }
    }
}
