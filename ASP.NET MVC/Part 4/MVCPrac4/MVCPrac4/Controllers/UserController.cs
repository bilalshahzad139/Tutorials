using MVCPrac1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPrac1.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Login()
        {
            return PartialView("LoginPartial");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Register(String name, String login, string password)
        {
            ViewBag.Name = name;
            ViewBag.Login = login;
            ViewBag.Password = password;
            ViewData["Message"] = "Information is Invalid!";
            return View();
        }

        [HttpGet]
        public ActionResult Register2()
        {
            var dto = new UserDTO();
            return View(dto);
        } 
        [HttpPost]
        public ActionResult Register2(UserDTO dto)
        {
            ViewBag.Message = "Testing";
            return View(dto);
        }
        
    }
}
