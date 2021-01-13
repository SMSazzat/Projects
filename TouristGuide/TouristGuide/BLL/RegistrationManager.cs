using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class RegistrationManager
    {
        RegistrationRepository _registrationRepository = new RegistrationRepository();

        public bool Add(Registration registration)
        {
            return _registrationRepository.Add(registration);
        }

        public List<Registration> GetAll()
        {
            return _registrationRepository.GetAll();
        }
    }
}