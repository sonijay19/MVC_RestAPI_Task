using DemoService.ClientLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using Microsoft.Extensions.DependencyInjection;

namespace UserManageMentSerivces.Controllers
{
    [ApiController]
    [Route("api/v1/GetUserDetails")]
    public class GetUserDetailsController : ControllerBase
    {
        private IGetAllUserData client;
        public GetUserDetailsController(IServiceProvider service)
        {
            client = service.GetService<IGetAllUserData>();
        }

        [HttpGet]   
        public async Task<IActionResult> Get()
        {
            //soni1@gmail.com
            UserLoginRequestMessages request = new UserLoginRequestMessages();
            request.UserEmail = "soni1@gmail.com";
            var response = await client.GetUserInformationAsync(request);
            return Ok(response);
        }
    }
}
