using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class PoliceStationRepository
    {
        TourDb _db = new TourDb();

        public bool Add(PoliceStation policeStation)

        {
            int isExecuted = 0;

            _db.PoliceStations.Add(policeStation);

            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(PoliceStation policeStation)
        {
            int isExecuted = 0;
            PoliceStation apoliceStation = _db.PoliceStations.FirstOrDefault(c => c.Id == policeStation.Id);
            if (apoliceStation != null)
            {
                apoliceStation.Name = policeStation.Name;
                apoliceStation.Address = policeStation.Address;
                apoliceStation.Contact = policeStation.Contact;
                apoliceStation.Dictrict = policeStation.Dictrict;
                isExecuted = _db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            else
                return false;
        }

        public PoliceStation GetById(PoliceStation policeStation)
        {
            PoliceStation apolicestation = _db.PoliceStations.FirstOrDefault(c => c.Id == policeStation.Id);
            return apolicestation;
        }

        public bool Delete(PoliceStation policeStation)
        {
            int isExecuted = 0;
            PoliceStation apoliceStation = _db.PoliceStations.FirstOrDefault(c => c.Id == policeStation.Id);

            if (apoliceStation == null)
            {
                return false;
            }

            _db.PoliceStations.Remove(apoliceStation);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<PoliceStation> GetAll()
        {
            return _db.PoliceStations.ToList();
        }
    }
}