using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristGuide.Models;
using TouristGuide.Repositories;

namespace TouristGuide.BLL
{
    public class AdminManager
    {
        AdminRepository _adminRepository = new AdminRepository();

        public List<Admin> GetAll()
        {
            return _adminRepository.GetAll();
        }
    }
}