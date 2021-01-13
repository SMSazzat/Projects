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
    public class HotelController : Controller
    {
        HotelManager _hotelManager = new HotelManager();
        DistrictManager _districtManager = new DistrictManager();
        Hotel _hotel = new Hotel();
        Hotel _showHotel = new Hotel();

        [HttpGet]
        public ActionResult Add()
        {
            Hotel hotel = new Hotel();
            hotel.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            return View(hotel);
        }

        [HttpPost]
        public ActionResult Add(Hotel hotel)
        {
            string fileName = Path.GetFileNameWithoutExtension(hotel.ImageFile.FileName);
            string extension = Path.GetExtension(hotel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            hotel.Image = "~/Image/Hotels/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Hotels/"), fileName);
            hotel.ImageFile.SaveAs(fileName);

            if (_hotelManager.Add(hotel))
            {
                ViewBag.successMsg = "Saved";
            }

            else
            {
                ViewBag.failMsg = "Failed to save";
            }


            hotel.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();
            return View(hotel);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            _hotel.Id = id;
            var ahotel = _hotelManager.GetById(_hotel);
            ahotel.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();
            return View(ahotel);
        }

        [HttpPost]
        public ActionResult Update(Hotel hotel)
        {
            string fileName = Path.GetFileNameWithoutExtension(hotel.ImageFile.FileName);
            string extension = Path.GetExtension(hotel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            hotel.Image = "~/Image/Hotels/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Hotels/"), fileName);
            hotel.ImageFile.SaveAs(fileName);


            if (_hotelManager.Update(hotel))
            {
                ViewBag.successMsg = "Updated";
            }

            else
            {
                ViewBag.failMsg = "Upadte failed";
            }


            hotel.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();

            return View(hotel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _hotel.Id = id;
            var ahotel = _hotelManager.GetById(_hotel);
            return View(ahotel);
        }

        [HttpPost]
        public ActionResult Delete(Hotel hotel)
        {
            if (_hotelManager.Delete(hotel))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(hotel);
        }

        [HttpGet]
        public ActionResult Show()
        {
            _hotel.Hotels = _hotelManager.GetAll();
            if (_hotel.Hotels.Count == 0)
            {
                ViewBag.Msg = "No hotel found";
            }
            return View(_hotel);
        }

        [HttpPost]
        public ActionResult Show(string name)
        {
            var hotels = _hotelManager.GetAll();

            if (name != null)
            {
                hotels = hotels.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            _hotel.Hotels = hotels;
            return View(_hotel);
        }


        [HttpGet]
        public ActionResult ShowHotel()
        {
            _hotel.Hotels = _hotelManager.GetAll();
            if (_hotel.Hotels.Count == 0)
            {
                ViewBag.Msg = "No hotel found";
            }
            return View(_hotel);
        }

        [HttpPost]
        public ActionResult ShowHotel(string district)
        {
            var hotels = _hotelManager.GetAll();

            if (district != null)
            {
                hotels = hotels.Where(c => c.Dictrict.ToLower().Contains(district.ToLower())).ToList();
            }

            _hotel.Hotels = hotels;
            if (_hotel.Hotels.Count > 0)
                return View(_hotel);
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