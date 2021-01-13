using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class DistrictManager
    {

        DistrictRepository _districtRepository = new DistrictRepository();

        public bool Add(District district)
        {
            return _districtRepository.Add(district);
        }

        public bool Delete(District district)
        {
            return _districtRepository.Delete(district);
        }

        public District GetByName(District district)
        {
            return _districtRepository.GetByName(district);
        }

        public District GetByCode(District district)
        {
            return _districtRepository.GetByCode(district);
        }

        public List<District> GetAll()
        {
            return _districtRepository.GetAll();
        }
    }
}