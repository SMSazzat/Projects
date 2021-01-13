using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class PoliceStationController : Controller
    {
        PoliceStationManager _policeStationManager = new PoliceStationManager();
        DistrictManager _districtManager = new DistrictManager();
        PoliceStation _policeStation = new PoliceStation();
        PoliceStation _showPoliceStation = new PoliceStation();

        [HttpGet]
        public ActionResult Add()
        {
            PoliceStation policeStation = new PoliceStation();
            policeStation.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            return View(policeStation);
        }


        [HttpPost]
        public ActionResult Add(PoliceStation policeStation)
        {
            if (_policeStationManager.Add(policeStation))
            {
                ViewBag.successMsg = "Saved";
            }

            else
            {
                ViewBag.failMsg = "Failed to save";
            }


            policeStation.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();
            return View(policeStation);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            _policeStation.Id = id;
            var apoliceStation = _policeStationManager.GetById(_policeStation);
            apoliceStation.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();
            return View(apoliceStation);
        }

        [HttpPost]
        public ActionResult Update(PoliceStation policeStation)
        {
           
            if (_policeStationManager.Update(policeStation))
            {
                ViewBag.successMsg = "Updated";
            }

            else
            {
                ViewBag.failMsg = "Upadte failed";
            }


            policeStation.DistrictSelectListItems = _districtManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.DistrictName,
                Text = c.DistrictName

            }).ToList();

            ModelState.Clear();

            return View(policeStation);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            _policeStation.Id = id;
            var apoliceStation = _policeStationManager.GetById(_policeStation);
            return View(apoliceStation);
        }


        [HttpPost]
        public ActionResult Delete(PoliceStation policeStation)
        {
            if (_policeStationManager.Delete(policeStation))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(policeStation);
        }

        [HttpGet]
        public ActionResult Show()
        {
            _policeStation.PoliceStations = _policeStationManager.GetAll();
            if (_policeStation.PoliceStations.Count == 0)
            {
                ViewBag.Msg = "No Police Station found";
            }
            return View(_policeStation);
        }


        [HttpPost]
        public ActionResult Show(string name)
        {
            var policeStations = _policeStationManager.GetAll();

            if (name != null)
            {
                policeStations = policeStations.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            _policeStation.PoliceStations = policeStations;
            return View(_policeStation);
        }

        [HttpGet]
        public ActionResult ShowPoliceStation()
        {
            _policeStation.PoliceStations = _policeStationManager.GetAll();
            if (_policeStation.PoliceStations.Count == 0)
            {
                ViewBag.Msg = "No Police Station found";
            }
            return View(_policeStation);
        }


        [HttpPost]
        public ActionResult ShowPoliceStation(string district)
        {
            var policeStations = _policeStationManager.GetAll();

            if (district != null)
            {
                policeStations = policeStations.Where(c => c.Dictrict.ToLower().Contains(district.ToLower())).ToList();
            }

            _policeStation.PoliceStations = policeStations;
            if (_policeStation.PoliceStations.Count > 0)
                return View(_policeStation);
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