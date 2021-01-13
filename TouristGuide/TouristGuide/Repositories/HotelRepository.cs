using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class HotelRepository
    {
        TourDb _db = new TourDb();

        public bool Add(Hotel hotel)

        {
            int isExecuted = 0;

            _db.Hotels.Add(hotel);

            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(Hotel hotel)
        {
            int isExecuted = 0;
            Hotel ahotel = _db.Hotels.FirstOrDefault(c => c.Id == hotel.Id);
            if (ahotel != null)
            {
                ahotel.Name = hotel.Name;
                ahotel.Address = hotel.Address;
                ahotel.Contact = hotel.Contact;
                ahotel.Dictrict = hotel.Dictrict;
                ahotel.Image = hotel.Image;
                isExecuted = _db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            else
                return false;
        }

        public Hotel GetById(Hotel hotel)
        {
            Hotel ahotel = _db.Hotels.FirstOrDefault(c => c.Id == hotel.Id);
            return ahotel;
        }

        public bool Delete(Hotel hotel)
        {
            int isExecuted = 0;
            Hotel ahotel = _db.Hotels.FirstOrDefault(c => c.Id == hotel.Id);

            if (ahotel == null)
            {
                return false;
            }

            _db.Hotels.Remove(ahotel);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Hotel> GetAll()
        {
            return _db.Hotels.ToList();
        }
    }
}