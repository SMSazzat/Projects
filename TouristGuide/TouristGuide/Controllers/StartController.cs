using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;

namespace TouristGuide.Controllers
{
    public class StartController : Controller
    {
        AdminManager _adminManager = new AdminManager();

        // GET: Start
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string admin)
        {
            if(admin != "allow")
            {
                return View("NotFound");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password)
        {

            var admins = _adminManager.GetAll();

            admins = admins.Where(c => c.AdminName == username && c.Password == password).ToList();

            if (admins.Count > 0)
            {
                return View("Home");
            }

            else
            {
                ViewBag.wrong = "Wrong username or password!";
            }
            return View();

            //if ((username == "sazzad")&&(password == "letmein"))
            //{
            //    return View("Home");
            //}
            //else
            //{
            //    ViewBag.wrong = "Wrong username or password!";
            //}
            //return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

    }
}