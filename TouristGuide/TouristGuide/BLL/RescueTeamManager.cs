using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class RescueTeamManager
    {
        RescueTeamRepository _rescueTeamRepository = new RescueTeamRepository();

        public bool Add(RescueTeam rescueTeam)
        {
            return _rescueTeamRepository.Add(rescueTeam);
        }

        public bool Update(RescueTeam rescueTeam)
        {
            return _rescueTeamRepository.Update(rescueTeam);
        }

        public RescueTeam GetById(RescueTeam rescueTeam)
        {
            return _rescueTeamRepository.GetById(rescueTeam);
        }

        public bool Delete(RescueTeam rescueTeam)
        {
            return _rescueTeamRepository.Delete(rescueTeam);
        }

        public List<RescueTeam> GetAll()
        {
            return _rescueTeamRepository.GetAll();
        }
    }
}