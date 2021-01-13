using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class RentCarManager
    {
        RentCarRepository _rentCarRepository = new RentCarRepository();

        public bool Add(RentCar rentCar)
        {
            return _rentCarRepository.Add(rentCar);
        }

        public bool Update(RentCar rentCar)
        {
            return _rentCarRepository.Update(rentCar);
        }

        public RentCar GetById(RentCar rentCar)
        {
            return _rentCarRepository.GetById(rentCar);
        }

        public bool Delete(RentCar rentCar)
        {
            return _rentCarRepository.Delete(rentCar);
        }

        public List<RentCar> GetAll()
        {
            return _rentCarRepository.GetAll();
        }
    }
}