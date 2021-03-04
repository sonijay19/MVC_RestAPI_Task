using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer;
using UserManageMentSerivces.ClientLayer.Entites.DTO.RequestMessages;

namespace UserManageMentSerivces.Controllers
{
    [ApiController]
    [Route("api/v1/DeleteUser")]
    public class DeleteUserController : Controller
    {
        [HttpDelete]
        public async Task<IActionResult> Get(DeleteUserDetailsRequestMessage userDetails)
        {
            var response = await ClientServiceManager.GetInstance().RemoveUserInformation()
                .DeleteUserDetailsAsync(userDetails.UserId);
            return Ok(response);
        }
    }
}
