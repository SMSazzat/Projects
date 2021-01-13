using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class SpotRepository
    {
        TourDb _db = new TourDb();

        public bool Add(Spot spot)

        {
            int isExecuted = 0;

            _db.Spots.Add(spot);

            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(Spot spot)
        {
            int isExecuted = 0;
            Spot aspot = _db.Spots.FirstOrDefault(c => c.Id == spot.Id);
            if (aspot != null)
            {
                aspot.Name = spot.Name;
                aspot.Dictrict = spot.Dictrict;
                aspot.Image = spot.Image;
                aspot.Description = spot.Description;
                aspot.Location = spot.Location;
                isExecuted = _db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            else
                return false;
        }

        public Spot GetById(Spot spot)
        {
            Spot aspot = _db.Spots.FirstOrDefault(c => c.Id == spot.Id);
            return aspot;
        }

        public Spot GetByName(Spot spot)
        {
            Spot aspot = _db.Spots.FirstOrDefault(c => c.Name == spot.Name);
            return aspot;
        }

        public bool Delete(Spot spot)
        {
            int isExecuted = 0;
            Spot aspot = _db.Spots.FirstOrDefault(c => c.Id == spot.Id);

            if (aspot == null)
            {
                return false;
            }

            _db.Spots.Remove(aspot);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Spot> GetAll()
        {
            return _db.Spots.ToList();
        }
    }
}