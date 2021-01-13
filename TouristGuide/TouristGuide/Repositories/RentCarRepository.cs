using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class RentCarRepository
    {
        TourDb _db = new TourDb();

        public bool Add(RentCar rentcar)

        {
            int isExecuted = 0;

            _db.RentCars.Add(rentcar);

            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(RentCar rentCar)
        {
            int isExecuted = 0;
            RentCar arentCar = _db.RentCars.FirstOrDefault(c => c.Id == rentCar.Id);
            if (arentCar != null)
            {
                arentCar.Name = rentCar.Name;
                arentCar.Address = rentCar.Address;
                arentCar.Contact = rentCar.Contact;
                arentCar.Dictrict = rentCar.Dictrict;
                isExecuted = _db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            else
                return false;
        }

        public RentCar GetById(RentCar rentCar)
        {
            RentCar arentCar = _db.RentCars.FirstOrDefault(c => c.Id == rentCar.Id);
            return arentCar;
        }

        public bool Delete(RentCar rentCar)
        {
            int isExecuted = 0;
            RentCar arentCar = _db.RentCars.FirstOrDefault(c => c.Id == rentCar.Id);

            if (arentCar == null)
            {
                return false;
            }

            _db.RentCars.Remove(arentCar);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<RentCar> GetAll()
        {
            return _db.RentCars.ToList();
        }
    }
}