using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class SpotManager
    {
        SpotRepository _spotRepository = new SpotRepository();

        public bool Add(Spot spot)
        {
            return _spotRepository.Add(spot);
        }

        public bool Update(Spot spot)
        {
            return _spotRepository.Update(spot);
        }

        public Spot GetById(Spot spot)
        {
            return _spotRepository.GetById(spot);
        }

        public Spot GetByName(Spot spot)
        {
            return _spotRepository.GetByName(spot);
        }

        public bool Delete(Spot spot)
        {
            return _spotRepository.Delete(spot);
        }

        public List<Spot> GetAll()
        {
            return _spotRepository.GetAll();
        }
    }
}