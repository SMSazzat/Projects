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
    public class ShoppingMallController : Controller
    {
        ShoppingMallManager _shoppingMallManager = new ShoppingMallManager();
        DistrictManager _districtManager = new DistrictManager();
        ShoppingMall _shoppingMall = new ShoppingMall();

        [HttpGet]
        public ActionResult Add()
        {
            ShoppingMall shoppingMall = new ShoppingMall();
            shoppingMall.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            return View(shoppingMall);
        }

        [HttpPost]
        public ActionResult Add(ShoppingMall shoppingMall)
        {
            string fileName = Path.GetFileNameWithoutExtension(shoppingMall.ImageFile.FileName);
            string extension = Path.GetExtension(shoppingMall.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            shoppingMall.Image = "~/Image/ShoppingMalls/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/ShoppingMalls/"), fileName);
            shoppingMall.ImageFile.SaveAs(fileName);

            if (_shoppingMallManager.Add(shoppingMall))
            {
                ViewBag.successMsg = "Saved";
            }

            else
            {
                ViewBag.failMsg = "Failed to save";
            }


            shoppingMall.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();
            return View(shoppingMall);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            _shoppingMall.Id = id;
            var ashoppingMall = _shoppingMallManager.GetById(_shoppingMall);
            ashoppingMall.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();
            return View(ashoppingMall);
        }

        [HttpPost]
        public ActionResult Update(ShoppingMall shoppingMall)
        {
            string fileName = Path.GetFileNameWithoutExtension(shoppingMall.ImageFile.FileName);
            string extension = Path.GetExtension(shoppingMall.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            shoppingMall.Image = "~/Image/ShoppingMalls/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/ShoppingMalls/"), fileName);
            shoppingMall.ImageFile.SaveAs(fileName);


            if (_shoppingMallManager.Update(shoppingMall))
            {
                ViewBag.successMsg = "Updated";
            }

            else
            {
                ViewBag.failMsg = "Upadte failed";
            }


            shoppingMall.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();

            return View(shoppingMall);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _shoppingMall.Id = id;
            var ashoppingMall = _shoppingMallManager.GetById(_shoppingMall);
            return View(ashoppingMall);
        }

        [HttpPost]
        public ActionResult Delete(ShoppingMall shoppingMall)
        {
            if (_shoppingMallManager.Delete(shoppingMall))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(shoppingMall);
        }


        [HttpGet]
        public ActionResult Show()
        {
            _shoppingMall.ShoppingMalls = _shoppingMallManager.GetAll();
            if (_shoppingMall.ShoppingMalls.Count == 0)
            {
                ViewBag.Msg = "No Shopping Mall found";
            }
            return View(_shoppingMall);
        }

        [HttpPost]
        public ActionResult Show(string name)
        {
            var shoppingMalls = _shoppingMallManager.GetAll();

            if (name != null)
            {
                shoppingMalls = shoppingMalls.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            _shoppingMall.ShoppingMalls = shoppingMalls;
            return View(_shoppingMall);
        }

        [HttpGet]
        public ActionResult ShowShoppingMall()
        {
            _shoppingMall.ShoppingMalls = _shoppingMallManager.GetAll();
            if (_shoppingMall.ShoppingMalls.Count == 0)
            {
                ViewBag.Msg = "No Shopping Mall found";
            }
            return View(_shoppingMall);
        }

        [HttpPost]
        public ActionResult ShowShoppingMall(string district)
        {
            var shoppingMalls = _shoppingMallManager.GetAll();

            if (district != null)
            {
                shoppingMalls = shoppingMalls.Where(c => c.Dictrict.ToLower().Contains(district.ToLower())).ToList();
            }

            _shoppingMall.ShoppingMalls = shoppingMalls;
            if (_shoppingMall.ShoppingMalls.Count > 0)
                return View(_shoppingMall);
            else
                return RedirectToAction("NotFound");
        }

        public ActionResult NotFound()
        {
            ViewBag.msg = "Nothing found related to your search";
            return View();
        }
    }
}