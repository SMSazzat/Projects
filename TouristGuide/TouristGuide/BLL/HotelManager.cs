using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class HotelManager
    {
        HotelRepository _hotelRepository = new HotelRepository();

        public bool Add(Hotel hotel)
        {
            return _hotelRepository.Add(hotel);
        }

        public bool Update(Hotel hotel)
        {
            return _hotelRepository.Update(hotel);
        }

        public Hotel GetById(Hotel hotel)
        {
            return _hotelRepository.GetById(hotel);
        }

        public bool Delete(Hotel hotel)
        {
            return _hotelRepository.Delete(hotel);
        }

        public List<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }
    }
}