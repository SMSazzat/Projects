using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristGuide.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        public string AdminName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}