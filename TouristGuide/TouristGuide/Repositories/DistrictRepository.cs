using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class DistrictRepository
    {
        TourDb _db = new TourDb();

        public bool Add(District district)
        {
            int isExecuted = 0;

            _db.Districts.Add(district);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool Delete(District district)
        {
            int isExecuted = 0;
            District adistrict = _db.Districts.FirstOrDefault(c => c.DistrictName == district.DistrictName);

            if(adistrict == null)
            {
                return false;
            }

            _db.Districts.Remove(adistrict);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public District GetByName(District district)
        {
            District adistrict = _db.Districts.FirstOrDefault(c => c.DistrictName == district.DistrictName);
            return adistrict;
        }

        public District GetByCode(District district)
        {
            District adistrict = _db.Districts.FirstOrDefault(c => c.DistrictCode == district.DistrictCode);
            return adistrict;
        }

        public List<District> GetAll()
        {
            return _db.Districts.ToList();
        }
    }
}