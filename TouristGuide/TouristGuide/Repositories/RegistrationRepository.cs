using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class RegistrationRepository
    {
        TourDb _db = new TourDb();

        public bool Add(Registration registration)
        {
            int isExecuted = 0;

            _db.Registrations.Add(registration);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Registration> GetAll()
        {
            return _db.Registrations.ToList();
        }
    }
}