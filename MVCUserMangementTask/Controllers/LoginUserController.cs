using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCUserMangementTask.CallAPIs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using MVCUserMangementTask.Models.UserLogin;

namespace MVCUserMangementTask.Controllers
{
    public class LoginUserController : Controller
    {
        public static string AccessType { get; set; }
        public IActionResult Index()
        {
            ViewBag.Errors = "";
            return View("Index");
        }

        private static string Baseurl = "https://localhost:44372/";
        [HttpPost]
        public async Task<IActionResult> Index(UserRequestModel userDetails)
        {
            LoginUserResponseMessages userInformation = new LoginUserResponseMessages();
            string errorMessage = String.Empty;
            if (ModelState.IsValid)
            {
                string apiURI = Baseurl + "api/v1/LoginUser";
                var client = ConsumeAPIs.GetClient(apiURI);
                StringContent content = new StringContent(JsonConvert.SerializeObject(userDetails), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync(apiURI, content))
                {
                    userInformation = await response.Content.ReadAsAsync<LoginUserResponseMessages>();
                }
                Debug.Write(userInformation);
                if (userInformation.UserDetails != null)
                {
                    ViewBag.response = userInformation.UserDetails.FirstName;
                    ViewBag.AccessType = userInformation.UserDetails.UserStatus;
                    AccessType = userInformation.UserDetails.UserStatus;
                    UserDetailsController.AccessTypeCon = userInformation.UserDetails.UserStatus;
                    HttpContext.Session.SetString("AccessType", userInformation.UserDetails.UserStatus);
                    return View("Home");
                }
                errorMessage = userInformation.ErrorCodes.ToString();
            }
            else
            {
                return View(userDetails);
            }
            ViewBag.Errors = errorMessage;
            return View();
            //return View();
            /*ViewBag.response = userInformation.UserDetails;
            return View("Home");*/
        }
    }
}
