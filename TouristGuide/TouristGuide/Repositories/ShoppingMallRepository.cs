using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class ShoppingMallRepository
    {
        TourDb _db = new TourDb();

        public bool Add(ShoppingMall shoppingMall)

        {
            int isExecuted = 0;

            _db.ShoppingMalls.Add(shoppingMall);

            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(ShoppingMall shoppingMall)
        {
            int isExecuted = 0;
            ShoppingMall ashoppingMall = _db.ShoppingMalls.FirstOrDefault(c => c.Id == shoppingMall.Id);
            if (ashoppingMall != null)
            {
                ashoppingMall.Name = shoppingMall.Name;
                ashoppingMall.Address = shoppingMall.Address;
                ashoppingMall.Dictrict = shoppingMall.Dictrict;
                ashoppingMall.Image = shoppingMall.Image;
                isExecuted = _db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            else
                return false;
        }

        public ShoppingMall GetById(ShoppingMall shoppingMall)
        {
            ShoppingMall ashoppingMall = _db.ShoppingMalls.FirstOrDefault(c => c.Id == shoppingMall.Id);
            return ashoppingMall;
        }

        public bool Delete(ShoppingMall shoppingMall)
        {
            int isExecuted = 0;
            ShoppingMall ashoppingMall = _db.ShoppingMalls.FirstOrDefault(c => c.Id == shoppingMall.Id);

            if (ashoppingMall == null)
            {
                return false;
            }

            _db.ShoppingMalls.Remove(ashoppingMall);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<ShoppingMall> GetAll()
        {
            return _db.ShoppingMalls.ToList();
        }
    }
}