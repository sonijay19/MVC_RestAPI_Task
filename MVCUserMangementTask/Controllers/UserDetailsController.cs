using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCUserMangementTask.Controllers
{
    public class UserDetailsController : Controller
    {
        public static string AccessTypeCon { get; set; }
        public IActionResult Index()
        {
            AccessTypeCon = LoginUserController.AccessType;
            ViewBag.Msg = LoginUserController.AccessType;
            return View();
        }
    }
}
