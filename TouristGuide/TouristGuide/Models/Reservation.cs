using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TouristGuide.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 6)]
        [Display(Name = "Contact")]
        public string Contact { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [NotMapped]
        public List<Reservation> Reservations { get; set; }
    }
}