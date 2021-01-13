using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class PackageRepository
    {
        TourDb _db = new TourDb();

        public bool Add(Package package)

        {
            int isExecuted = 0;

            _db.Packages.Add(package);

            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public Package GetById(Package package)
        {
            Package apackage = _db.Packages.FirstOrDefault(c => c.Id == package.Id);
            return apackage;
        }

        public bool Delete(Package package)
        {
            int isExecuted = 0;
            Package apackage = _db.Packages.FirstOrDefault(c => c.Id == package.Id);

            if (apackage == null)
            {
                return false;
            }

            _db.Packages.Remove(apackage);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Package> GetAll()
        {
            return _db.Packages.ToList();
        }
    }
}