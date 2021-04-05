using LogInApplication.BLL;
using LogInApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogInApplication.Controllers
{
    public class AdminController : Controller
    {

        UserAccountManager _userAccountManager = new UserAccountManager();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRegistration(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {

               
                if (_userAccountManager.Add(userAccount))
                {
                    ViewBag.successMsg = userAccount.UserName + " added";
                    ModelState.Clear();

                }

            }
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogIn logIn)
        {

            var admins = _userAccountManager.GetAll();
            admins = admins.Where(c => c.UserName == logIn.UserName && c.Password == logIn.Password).ToList();
            if (admins.Count > 0)
                ViewBag.msg = "yes";

            else
                ViewBag.msg = "no";

                return View("Home");

            
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}