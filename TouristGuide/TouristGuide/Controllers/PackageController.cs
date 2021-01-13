using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class PackageController : Controller
    {
        PackageManager _packageManager = new PackageManager();    
        Package _package = new Package();

        [HttpGet]
        public ActionResult Add()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Add(Package package)
        {
            string fileName = Path.GetFileNameWithoutExtension(package.ImageFile.FileName);
            string extension = Path.GetExtension(package.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            package.Image = "~/Image/Packages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Packages/"), fileName);
            package.ImageFile.SaveAs(fileName);

           
            if (_packageManager.Add(package))
            {
                ViewBag.successMsg = "Package added";
            }

            else
            {
                ViewBag.failMsg = "Failed to add";
            }
          
            ModelState.Clear();
            return View(package);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _package.Id = id;
            var apackage = _packageManager.GetById(_package);
            return View(apackage);
        }

        [HttpPost]
        public ActionResult Delete(Package package)
        {
            if (_packageManager.Delete(package))
            {
                ViewBag.successMsg = "Package deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(package);
        }

        public ActionResult Show()
        {
            _package.Packages = _packageManager.GetAll();
            if (_package.Packages.Count == 0)
            {
                ViewBag.Msg = "No package found";
            }
            return View(_package);
        }

        public ActionResult ShowPackage()
        {
            _package.Packages = _packageManager.GetAll();
            if (_package.Packages.Count == 0)
            {
                ViewBag.Msg = "No package found";
            }
            return View(_package);
        }

    }
}