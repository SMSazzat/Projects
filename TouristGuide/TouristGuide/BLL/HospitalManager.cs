using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class HospitalManager
    {
        HospitalRepository _hospitalRepository = new HospitalRepository();

        public bool Add(Hospital hospital)
        {
            return _hospitalRepository.Add(hospital);
        }

        public bool Update(Hospital hospital)
        {
            return _hospitalRepository.Update(hospital);
        }

        public Hospital GetById(Hospital hospital)
        {
            return _hospitalRepository.GetById(hospital);
        }

        public bool Delete(Hospital hospital)
        {
            return _hospitalRepository.Delete(hospital);
        }

        public List<Hospital> GetAll()
        {
            return _hospitalRepository.GetAll();
        }
    }
}