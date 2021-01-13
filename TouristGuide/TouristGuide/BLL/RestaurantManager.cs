using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class RestaurantManager
    {
        RestaurantRepository _restaurantRepository = new RestaurantRepository();

        public bool Add(Restaurant restaurant)
        {
            return _restaurantRepository.Add(restaurant);
        }

        public bool Update(Restaurant restaurant)
        {
            return _restaurantRepository.Update(restaurant);
        }

        public Restaurant GetById(Restaurant restaurant)
        {
            return _restaurantRepository.GetById(restaurant);
        }

        public bool Delete(Restaurant restaurant)
        {
            return _restaurantRepository.Delete(restaurant);
        }

        public List<Restaurant> GetAll()
        {
            return _restaurantRepository.GetAll();
        }
    }
}