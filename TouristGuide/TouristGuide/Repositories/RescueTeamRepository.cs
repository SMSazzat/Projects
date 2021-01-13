using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.DatabaseContext;
using TouristGuide.Models;

namespace TouristGuide.Repositories
{
    public class RescueTeamRepository
    {
        TourDb _db = new TourDb();

        public bool Add(RescueTeam rescueTeam)

        {
            int isExecuted = 0;

            _db.RescueTeams.Add(rescueTeam);

            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(RescueTeam rescueTeam)
        {
            int isExecuted = 0;
            RescueTeam arescueTeam = _db.RescueTeams.FirstOrDefault(c => c.Id == rescueTeam.Id);
            if (arescueTeam != null)
            {
                arescueTeam.Name = rescueTeam.Name;
                arescueTeam.Contact = rescueTeam.Contact;
                arescueTeam.Dictrict = rescueTeam.Dictrict;
                isExecuted = _db.SaveChanges();
            }
            if (isExecuted > 0)
                return true;
            else
                return false;
        }

        public RescueTeam GetById(RescueTeam rescueTeam)
        {
            RescueTeam arescueTeam = _db.RescueTeams.FirstOrDefault(c => c.Id == rescueTeam.Id);
            return arescueTeam
;
        }

        public bool Delete(RescueTeam rescueTeam)
        {
            int isExecuted = 0;
            RescueTeam arescueTeam = _db.RescueTeams.FirstOrDefault(c => c.Id == rescueTeam.Id);

            if (arescueTeam == null)
            {
                return false;
            }

            _db.RescueTeams.Remove(arescueTeam);
            isExecuted = _db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<RescueTeam> GetAll()
        {
            return _db.RescueTeams.ToList();
        }
    }
}