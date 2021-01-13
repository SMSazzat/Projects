using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class NearestSpotManager
    {
        NearestSpotRepository _nearestSpotRepository = new NearestSpotRepository();

        public bool Add(NearestSpot nearestSpot)
        {
            return _nearestSpotRepository.Add(nearestSpot);
        }

        public bool SpotExist(NearestSpot nearestSpot)
        {
            return _nearestSpotRepository.SpotExist(nearestSpot);
        }

        public NearestSpot GetById(NearestSpot nearestSpot)
        {
            return _nearestSpotRepository.GetById(nearestSpot);
        }

        public bool Delete(NearestSpot nearestSpot)
        {
            return _nearestSpotRepository.Delete(nearestSpot);
        }

        public List<NearestSpot> GetAll()
        {
            return _nearestSpotRepository.GetAll();
        }
    }
}