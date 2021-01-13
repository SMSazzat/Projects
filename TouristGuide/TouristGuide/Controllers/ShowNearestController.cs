using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TouristGuide.BLL;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Controllers
{
    public class ShowNearestController : Controller
    {
        public NearestSpotManager _nearestSpotManager = new NearestSpotManager();
        public NearestSpot _nearestSpot = new NearestSpot();
        TourDb _db = new TourDb();
        Spot _spot = new Spot();
     
        public ActionResult GetSpot(string name)
        {

            var nearestSpots = _nearestSpotManager.GetAll();

            if (name != null)
            {
                nearestSpots = nearestSpots.Where(c => c.Spot==name).ToList();
            }         

            foreach(var spot in nearestSpots)
            {
               Spot aspot = _db.Spots.FirstOrDefault(c => c.Name==spot.NearbySpot);
                _nearestSpot.Spots.Add(aspot);
            }

            return View(_nearestSpot);
        }
    }
}