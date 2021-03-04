using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer;
using UserManageMentSerivces.ClientLayer.RequestMessages;

namespace UserManageMentSerivces.Controllers
{
    [ApiController]
    [Route("api/v1/CreateUser")]
    public class CreateUserController : Controller
    {
        private readonly ILogger<CreateUserController> _logger;
        public CreateUserController(ILogger<CreateUserController> logger)
        {
            _logger = logger;
        }
        [HttpPut]
        public async Task<IActionResult> Index(UserUpdateRequestMessage request)
        {
            _logger.LogInformation("You are in CreateUser Controller");
            var response = await ClientServiceManager.GetInstance().AddUserInfo()
                .InsertUserDetailsAsync(request);
            return Ok(response);
        }
    }
}
