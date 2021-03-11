using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using Microsoft.Extensions.DependencyInjection;

namespace UserManageMentSerivces.Controllers
{
    [ApiController]
    [Route("api/v1/UpdateUserDetails")]
    public class UpdateUserDetailsController : ControllerBase
    {
        private IClientUserUpdateServices updateService;
        public UpdateUserDetailsController(IServiceProvider serviceProvider)
        {
            updateService = serviceProvider.GetService<IClientUserUpdateServices>();
        }
        [HttpPut]
        public async Task<IActionResult> Get(UserUpdateRequestMessage request)
        {
            var response = await updateService.UpdateUserDetailsAsync(request);
            return Ok(response);
        }
    }
}
