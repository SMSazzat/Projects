using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class RentCarController : Controller
    {
        RentCarManager _rentCarManager = new RentCarManager();
        DistrictManager _districtManager = new DistrictManager();
        RentCar _rentCar = new RentCar();
        RentCar _showrentCar = new RentCar();

        [HttpGet]
        public ActionResult Add()
        {
            RentCar rentCar = new RentCar();
            rentCar.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            return View(rentCar);
        }

        [HttpPost]
        public ActionResult Add(RentCar rentCar)
        {
            if (_rentCarManager.Add(rentCar))
            {
                ViewBag.successMsg = "Saved";
            }

            else
            {
                ViewBag.failMsg = "Failed to save";
            }


            rentCar.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();
            return View(rentCar);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            _rentCar.Id = id;
            var arentCar = _rentCarManager.GetById(_rentCar);
            arentCar.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();
            return View(arentCar);
        }

        [HttpPost]
        public ActionResult Update(RentCar rentCar)
        {

            if (_rentCarManager.Update(rentCar))
            {
                ViewBag.successMsg = "Updated";
            }

            else
            {
                ViewBag.failMsg = "Upadte failed";
            }


            rentCar.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();

            return View(rentCar);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            _rentCar.Id = id;
            var arentCar = _rentCarManager.GetById(_rentCar);
            return View(arentCar);
        }


        [HttpPost]
        public ActionResult Delete(RentCar rentCar)
        {
            if (_rentCarManager.Delete(rentCar))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(rentCar);
        }

        [HttpGet]
        public ActionResult Show()
        {
            _rentCar.RentCars = _rentCarManager.GetAll();
            if (_rentCar.RentCars.Count == 0)
            {
                ViewBag.Msg = "No Rent a car found";
            }
            return View(_rentCar);
        }


        [HttpPost]
        public ActionResult Show(string name)
        {
            var rentCars = _rentCarManager.GetAll();

            if (name != null)
            {
                rentCars = rentCars.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            _rentCar.RentCars = rentCars;
            return View(_rentCar);
        }


        [HttpGet]
        public ActionResult ShowRentCar()
        {
            _rentCar.RentCars = _rentCarManager.GetAll();
            if (_rentCar.RentCars.Count == 0)
            {
                ViewBag.Msg = "No Rent a car found";
            }
            return View(_rentCar);
        }


        [HttpPost]
        public ActionResult ShowRentCar(string district)
        {
            var rentCars = _rentCarManager.GetAll();

            if (district != null)
            {
                rentCars = rentCars.Where(c => c.Dictrict.ToLower().Contains(district.ToLower())).ToList();
            }

            _rentCar.RentCars = rentCars;
            if (_rentCar.RentCars.Count > 0)
                return View(_rentCar);
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