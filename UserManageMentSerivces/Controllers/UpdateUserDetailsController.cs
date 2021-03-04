using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer;
using UserManageMentSerivces.ClientLayer.RequestMessages;

namespace UserManageMentSerivces.Controllers
{
    [ApiController]
    [Route("api/v1/UpdateUserDetails")]
    public class UpdateUserDetailsController : ControllerBase
    {
        [HttpPut]
        public async Task<IActionResult> Get(UserUpdateRequestMessage request)
        {
            var response = await ClientServiceManager.GetInstance().UpdateUserInformation()
                .   UpdateUserDetailsAsync(request);
            return Ok(response);
        }
    }
}
