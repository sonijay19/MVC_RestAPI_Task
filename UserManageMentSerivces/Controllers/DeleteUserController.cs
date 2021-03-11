using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.ClientLayer;
using UserManageMentSerivces.ClientLayer.Entites.DTO.RequestMessages;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;

namespace UserManageMentSerivces.Controllers
{
    [ApiController]
    [Route("api/v1/DeleteUser")]
    public class DeleteUserController : Controller
    {
        private IDeleteUserInformation deleteUser;
        public DeleteUserController(IDeleteUserInformation deleteUserInformation)
        {
            deleteUser = deleteUserInformation;
        }
        [HttpDelete]
        public async Task<IActionResult> Get(DeleteUserDetailsRequestMessage userDetails)
        {
            var response = await deleteUser.DeleteUserDetailsAsync(userDetails.UserId);
            return Ok(response);
        }
    }
}
