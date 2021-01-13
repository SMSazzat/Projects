using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class AdminRepository
    {
        TourDb _db = new TourDb();

        public List<Admin> GetAll()
        {
            return _db.Admins.ToList();
        }
    }
}