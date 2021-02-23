using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCUserMangementTask.CallAPIs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MVCUserMangementTask.Controllers.RequestMessages;
using System.Text;
using Newtonsoft.Json;

namespace MVCUserMangementTask.Controllers
{
    public class LoginUserController : Controller
    {
        private static string Baseurl = "https://localhost:44372/";
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginRequestMessage userEmail)
        {
            UserLoginRequestMessage userDetails = new UserLoginRequestMessage();
            LoginUserResponseMessages userInformation = new LoginUserResponseMessages();
            string apiURI = Baseurl+"api/v1/LoginUser";
            userDetails.UserEmail = userEmail.UserEmail;
            var client = ConsumeAPIs.GetClient(apiURI);
            StringContent content = new StringContent(JsonConvert.SerializeObject(userDetails), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync(apiURI, content))
            {
                userInformation = await response.Content.ReadAsAsync<LoginUserResponseMessages>();
            }
            if(userInformation.UserDetails == null)
            {
                ViewBag.errorShow = userInformation.ErrorCodes.ToString();
                Response.Redirect("Home/Index");
            }
            ViewBag.response = userInformation.UserDetails.FirstName;
            return View("Home");
        }
    }
}
