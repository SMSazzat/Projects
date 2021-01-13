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
    public class RestaurantController : Controller
    {
        RestaurantManager _restaurantManager = new RestaurantManager();
        DistrictManager _districtManager = new DistrictManager();
        Restaurant _restaurant = new Restaurant();
       
        [HttpGet]
        public ActionResult Add()
        {
            Restaurant restaurant = new Restaurant();
            restaurant.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            return View(restaurant);
        }

        [HttpPost]
        public ActionResult Add(Restaurant restaurant)
        {
            string fileName = Path.GetFileNameWithoutExtension(restaurant.ImageFile.FileName);
            string extension = Path.GetExtension(restaurant.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            restaurant.Image = "~/Image/Restaurants/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Restaurants/"), fileName);
            restaurant.ImageFile.SaveAs(fileName);

            if (_restaurantManager.Add(restaurant))
            {
                ViewBag.successMsg = "Saved";
            }

            else
            {
                ViewBag.failMsg = "Failed to save";
            }


            restaurant.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            _restaurant.Id = id;
            var arestaurant = _restaurantManager.GetById(_restaurant);
            arestaurant.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();
            return View(arestaurant);
        }

        [HttpPost]
        public ActionResult Update(Restaurant restaurant)
        {
            string fileName = Path.GetFileNameWithoutExtension(restaurant.ImageFile.FileName);
            string extension = Path.GetExtension(restaurant.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            restaurant.Image = "~/Image/Restaurants/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Restaurants/"), fileName);
            restaurant.ImageFile.SaveAs(fileName);


            if (_restaurantManager.Update(restaurant))
            {
                ViewBag.successMsg = "Updated";
            }

            else
            {
                ViewBag.failMsg = "Upadte failed";
            }


            restaurant.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();

            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _restaurant.Id = id;
            var arestaurant = _restaurantManager.GetById(_restaurant);
            return View(arestaurant);
        }

        [HttpPost]
        public ActionResult Delete(Restaurant restaurant)
        {
            if (_restaurantManager.Delete(restaurant))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(restaurant);
        }


        [HttpGet]
        public ActionResult Show()
        {
            _restaurant.Restaurants = _restaurantManager.GetAll();
            if (_restaurant.Restaurants.Count == 0)
            {
                ViewBag.Msg = "No restaurant found";
            }
            return View(_restaurant);
        }

        [HttpPost]
        public ActionResult Show(string name)
        {
            var restaurants = _restaurantManager.GetAll();

            if (name != null)
            {
                restaurants = restaurants.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            _restaurant.Restaurants = restaurants;
            return View(_restaurant);
        }

        [HttpGet]
        public ActionResult ShowRestaurant()
        {
            _restaurant.Restaurants = _restaurantManager.GetAll();
            if (_restaurant.Restaurants.Count == 0)
            {
                ViewBag.Msg = "No restaurant found";
            }
            return View(_restaurant);
        }

        [HttpPost]
        public ActionResult ShowRestaurant(string district)
        {
            var restaurants = _restaurantManager.GetAll();

            if (district != null)
            {
                restaurants = restaurants.Where(c => c.Dictrict.ToLower().Contains(district.ToLower())).ToList();
            }

            _restaurant.Restaurants = restaurants;
            if (_restaurant.Restaurants.Count > 0)
                return View(_restaurant);
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