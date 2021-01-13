using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class ShoppingMallManager
    {
        ShoppingMallRepository _shoppingMallRepository = new ShoppingMallRepository();

        public bool Add(ShoppingMall shoppingMall)
        {
            return _shoppingMallRepository.Add(shoppingMall);
        }

        public bool Update(ShoppingMall shoppingMall)
        {
            return _shoppingMallRepository.Update(shoppingMall);
        }

        public ShoppingMall GetById(ShoppingMall shoppingMall)
        {
            return _shoppingMallRepository.GetById(shoppingMall);
        }

        public bool Delete(ShoppingMall shoppingMall)
        {
            return _shoppingMallRepository.Delete(shoppingMall);
        }

        public List<ShoppingMall> GetAll()
        {
            return _shoppingMallRepository.GetAll();
        }
    }
}