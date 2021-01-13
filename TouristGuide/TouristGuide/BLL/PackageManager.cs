using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class PackageManager
    {
        PackageRepository _packageRepository = new PackageRepository();

        public bool Add(Package package)
        {
            return _packageRepository.Add(package);
        }

        public Package GetById(Package package)
        {
            return _packageRepository.GetById(package);
        }

        public bool Delete(Package package)
        {
            return _packageRepository.Delete(package);
        }

        public List<Package> GetAll()
        {
            return _packageRepository.GetAll();
        }
    }
}