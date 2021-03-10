using DemoService.ClientLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using Microsoft.Extensions.DependencyInjection;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;

namespace UserManageMentSerivces.Controllers
{
    [ApiController]
    [Route("api/v1/LoginUser")]
    public class UserLoginController : ControllerBase
    {
        IUserUpdateAuthenticate client;
        public UserLoginController(IServiceProvider service)
        {
            client = service.GetService<IUserUpdateAuthenticate>();
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserLoginRequestMessages request)
        {
            var response = await client.AuthenticateUser(request);
            return Ok(response);
        }
    }
}
