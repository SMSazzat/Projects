using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class PoliceStationManager
    {
        PoliceStationRepository _PoliceStationRepository = new PoliceStationRepository();

        public bool Add(PoliceStation policeStation)
        {
            return _PoliceStationRepository.Add(policeStation);
        }

        public bool Update(PoliceStation policeStation)
        {
            return _PoliceStationRepository.Update(policeStation);
        }

        public PoliceStation GetById(PoliceStation policeStation)
        {
            return _PoliceStationRepository.GetById(policeStation);
        }

        public bool Delete(PoliceStation policeStation)
        {
            return _PoliceStationRepository.Delete(policeStation);
        }

        public List<PoliceStation> GetAll()
        {
            return _PoliceStationRepository.GetAll();
        }
    }
}