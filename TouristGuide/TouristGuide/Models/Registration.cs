using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristGuide.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Password { get; set; }
    }
}