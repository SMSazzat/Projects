using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class DistrictController : Controller
    {
        DistrictManager _districtManager = new DistrictManager();
        private District _district = new District();

        // GET: District

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(District district)
        {
            if(ModelState.IsValid)
            {
                var adistrict = _districtManager.GetByName(district);
                if(adistrict!=null)
                {
                    ViewBag.existMsg = "District altready exist with this name";
                    return View(district);
                }

                adistrict = _districtManager.GetByCode(district);
                if (adistrict != null)
                {
                    ViewBag.existMsg = "District altready exist with this Code";
                    return View(district);
                }

                if ( _districtManager.Add(district))
                {
                    ViewBag.successMsg = "District added";
                }
                else
                {
                    ViewBag.failMsg = "Failed";
                }
            }

            else
            {
                ViewBag.failMsg = "Validation error";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(string districtName)
        {
            _district.DistrictName = districtName;
            var district = _districtManager.GetByName(_district);
            return View(district);
        }

        [HttpPost]
        public ActionResult Delete(District district)
        {
            if( _districtManager.Delete(district))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "District deleted";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Show()
        {
             _district.Districts = _districtManager.GetAll();
            if(_district.Districts.Count == 0)
            {
                ViewBag.Msg = "No district found";
            }
            return View(_district);
        }

    }
}