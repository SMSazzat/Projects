using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class RestaurantRepository
    {
        TourDb _db = new TourDb();

        public bool Add(Restaurant restaurant)

        {
            int isExecuted = 0;

            _db.Restaurants.Add(restaurant);

            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(Restaurant restaurant)
        {
            int isExecuted = 0;
            Restaurant arestaurant = _db.Restaurants.FirstOrDefault(c => c.Id == restaurant.Id);
            if (arestaurant != null)
            {
                arestaurant.Name = restaurant.Name;
                arestaurant.Address = restaurant.Address;
                arestaurant.Contact = restaurant.Contact;
                arestaurant.Dictrict = restaurant.Dictrict;
                arestaurant.Image = restaurant.Image;
                isExecuted = _db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            else
                return false;
        }

        public Restaurant GetById(Restaurant restaurant)
        {
            Restaurant arestaurant = _db.Restaurants.FirstOrDefault(c => c.Id == restaurant.Id);
            return arestaurant;
        }

        public bool Delete(Restaurant restaurant)
        {
            int isExecuted = 0;
            Restaurant arestaurant = _db.Restaurants.FirstOrDefault(c => c.Id == restaurant.Id);

            if (arestaurant == null)
            {
                return false;
            }

            _db.Restaurants.Remove(arestaurant);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Restaurant> GetAll()
        {
            return _db.Restaurants.ToList();
        }
    }
}