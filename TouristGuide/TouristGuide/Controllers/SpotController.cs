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
    public class SpotController : Controller
    {
        SpotManager _spotManager = new SpotManager();
        DistrictManager _districtManager = new DistrictManager();
        Spot _spot = new Spot();

        [HttpGet]
        public ActionResult Add()
        {
            Spot spot = new Spot();
            spot.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            return View(spot);
        }

        [HttpPost]
        public ActionResult Add(Spot spot)
        {
            string fileName = Path.GetFileNameWithoutExtension(spot.ImageFile.FileName);
            string extension = Path.GetExtension(spot.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            spot.Image = "~/Image/Spots/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Spots/"), fileName);
            spot.ImageFile.SaveAs(fileName);

            var aspot = _spotManager.GetByName(spot);
            if (aspot != null)
            {
                Spot showSpot = new Spot();
                showSpot.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
                {
                    Value = c.DistrictName,
                    Text = c.DistrictName

                }).ToList();
                ViewBag.existMsg = "Spot already exist with this name";
                return View(showSpot);
            }

            if (_spotManager.Add(spot))
            {
                ViewBag.successMsg = "Saved";
            }

            else
            {
                ViewBag.failMsg = "Failed to save";
            }


            spot.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();
            return View(spot);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            _spot.Id = id;
            var aspot = _spotManager.GetById(_spot);
            aspot.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();
            return View(aspot);
        }

        [HttpPost]
        public ActionResult Update(Spot spot)
        {
            string fileName = Path.GetFileNameWithoutExtension(spot.ImageFile.FileName);
            string extension = Path.GetExtension(spot.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            spot.Image = "~/Image/Spots/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Spots/"), fileName);
            spot.ImageFile.SaveAs(fileName);

            var aspot = _spotManager.GetByName(spot);
            if (aspot != null)
            {

                Spot showSpot = new Spot();
                showSpot.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
                {
                    Value = c.DistrictName,
                    Text = c.DistrictName

                }).ToList();
                ViewBag.existMsg = "Spot already exist with this name";
                return View(showSpot);
            }

            if (_spotManager.Update(spot))
            {
                ViewBag.successMsg = "Updated";
            }

            else
            {
                ViewBag.failMsg = "Upadte failed";
            }


            spot.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();

            return View(spot);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _spot.Id = id;
            var aspot = _spotManager.GetById(_spot);
            return View(aspot);
        }

        [HttpPost]
        public ActionResult Delete(Spot spot)
        {
            if (_spotManager.Delete(spot))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(spot);
        }


        [HttpGet]
        public ActionResult Show()
        {
            _spot.Spots = _spotManager.GetAll();
            if (_spot.Spots.Count == 0)
            {
                ViewBag.Msg = "No spot found";
            }
            return View(_spot);
        }

        [HttpPost]
        public ActionResult Show(string name)
        {
            var spots = _spotManager.GetAll();

            if (name != null)
            {
                spots = spots.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            _spot.Spots = spots;
            return View(_spot);
        }


        [HttpGet]
        public ActionResult ShowSpot()
        {
            _spot.Spots = _spotManager.GetAll();
            if (_spot.Spots.Count == 0)
            {
                ViewBag.Msg = "No spot found";
            }
            return View(_spot);
        }

        [HttpPost]
        public ActionResult ShowSpot(string name)
        {
            if ((name != null)&&(name.Length>0))
            {
                var spots = _spotManager.GetAll();
                    spots = spots.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
                    if (spots.Count < 1)
                    {
                        spots = _spotManager.GetAll();
                        spots = spots.Where(c => c.Dictrict.ToLower().Contains(name.ToLower())).ToList();
                    }

                _spot.Spots = spots;
                if (_spot.Spots.Count > 0)
                    return View("Search", _spot);
                else
                    return RedirectToAction("NotFound");
            }

            else
            {
                var spots = _spotManager.GetAll();
                _spot.Spots = spots;
                return View(_spot);
            }
        }

        public ActionResult ViewSpot(int id)
        {
            var spots = _spotManager.GetAll();

            if (id != null)
            {
                spots = spots.Where(c => c.Id==id).ToList();
            }
            return View(spots);
        }

        public ActionResult Search()
        {
            return View(_spot);
        }

        public ActionResult NotFound()
        {
            ViewBag.msg = "Nothing found related to your search";
            return View();
        }

    }
}