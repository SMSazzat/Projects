using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class NearestSpotRepository
    {
        TourDb _db = new TourDb();

        public bool Add(NearestSpot nearestSpot)

        {
            int isExecuted = 0;

            _db.NearestSpots
.Add(nearestSpot);

            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool SpotExist(NearestSpot nearestSpot)
        {
            NearestSpot anearestSpot = _db.NearestSpots.FirstOrDefault((c => c.Spot == nearestSpot.Spot && c.NearbySpot==nearestSpot.NearbySpot));
            if (anearestSpot != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public NearestSpot GetById(NearestSpot nearestSpot)
        {
            NearestSpot anearestSpot = _db.NearestSpots.FirstOrDefault(c => c.Id == nearestSpot.Id);
            return anearestSpot;
        }

        public bool Delete(NearestSpot nearestSpot)
        {
            int isExecuted = 0;
            NearestSpot anearestSpot = _db.NearestSpots.FirstOrDefault(c => c.Id == nearestSpot.Id);

            if (anearestSpot == null)
            {
                return false;
            }

            _db.NearestSpots.Remove(anearestSpot);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<NearestSpot> GetAll()
        {
            return _db.NearestSpots.ToList();
        }
    }
}