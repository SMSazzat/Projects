using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class NearestSpotController : Controller
    {
        SpotManager _spotManager = new SpotManager();
        NearestSpot _nearestSpot = new NearestSpot();
        NearestSpotManager _nearestSpotManager = new NearestSpotManager();

        [HttpGet]
        public ActionResult Add()
        {
            NearestSpot nearestSpot = new NearestSpot();
            nearestSpot.SpotSelectListItems = _spotManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Name,
                Text = c.Name

            }).ToList();

            return View(nearestSpot);
        }

        [HttpPost]
        public ActionResult Add(NearestSpot nearestSpot)
        {
            if (_nearestSpotManager.SpotExist(nearestSpot))
            {
                NearestSpot showNearestSpot = new NearestSpot();
                showNearestSpot.SpotSelectListItems = _spotManager.GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Name,
                    Text = c.Name

                }).ToList();
                ViewBag.existMsg = nearestSpot.NearbySpot +" already exist nearby " +nearestSpot.Spot;
                return View(showNearestSpot);
            }

            if (_nearestSpotManager.Add(nearestSpot))
            {
                ViewBag.successMsg = "Saved";
            }

            else
            {
                ViewBag.failMsg = "Failed to save";
            }


            nearestSpot.SpotSelectListItems = _spotManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Name,
                Text = c.Name

            }).ToList();

            ModelState.Clear();
            return View(nearestSpot);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _nearestSpot.Id = id;
            var anearestSpot = _nearestSpotManager.GetById(_nearestSpot);
            return View(anearestSpot);
        }

        [HttpPost]
        public ActionResult Delete(NearestSpot nearestSpot)
        {
            if (_nearestSpotManager.Delete(nearestSpot))
            {
                ViewBag.successMsg = "Deleted";
            }
            else
            {
                ViewBag.failMsg = "Already deleted";
            }
            return View(nearestSpot);
        }

        [HttpGet]
        public ActionResult Show()
        {
            _nearestSpot.NearestSpots = _nearestSpotManager.GetAll();
            if (_nearestSpot.NearestSpots.Count == 0)
            {
                ViewBag.Msg = "No spot found";
            }
            return View(_nearestSpot);
        }

        [HttpPost]
        public ActionResult Show(string name)
        {
            var nearestSpots = _nearestSpotManager.GetAll();

            if (name != null)
            {
                nearestSpots = nearestSpots.Where(c => c.Spot.ToLower().Contains(name.ToLower())).ToList();
            }

            _nearestSpot.NearestSpots = nearestSpots;
            return View(_nearestSpot);
        }
    }
}