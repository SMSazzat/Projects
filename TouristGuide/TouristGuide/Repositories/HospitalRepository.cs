using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class HospitalRepository
    {
        TourDb _db = new TourDb();

        public bool Add(Hospital hospital)
        {
            int isExecuted = 0;

            _db.Hospitals.Add(hospital);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }


        public bool Update(Hospital hospital)
        {
            int isExecuted = 0;
            Hospital ahospital = _db.Hospitals.FirstOrDefault(c => c.Id == hospital.Id);
            if (ahospital != null)
            {
                ahospital.Name = hospital.Name;
                ahospital.Address = hospital.Address;
                ahospital.Contact = hospital.Contact;
                ahospital.Dictrict = hospital.Dictrict;
                ahospital.Image = hospital.Image;
                isExecuted = _db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            else
                return false;
        }


        public Hospital GetById(Hospital hospital)
        {
            Hospital ahospital = _db.Hospitals.FirstOrDefault(c => c.Id == hospital.Id);
            return ahospital;
        }

        public bool Delete(Hospital hospital)
        {
            int isExecuted = 0;
            Hospital ahospital = _db.Hospitals.FirstOrDefault(c => c.Id == hospital.Id);

            if (ahospital == null)
            {
                return false;
            }

            _db.Hospitals.Remove(ahospital);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Hospital> GetAll()
        {
            return _db.Hospitals.ToList();
        }
    }
}