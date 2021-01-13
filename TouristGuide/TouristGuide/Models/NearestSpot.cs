using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TouristGuide.Models
{
    public class NearestSpot
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field can not be empty")]       
        [Display(Name = "Spot Name")]
        public string Spot { get; set; }

        [Required(ErrorMessage = "Field can not be empty")]
        [Display(Name = "Nearby Spot")]
        public string NearbySpot { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> SpotSelectListItems { get; set; }

        [NotMapped]
        public List<NearestSpot> NearestSpots { get; set; }

        [NotMapped]
        public List<Spot> Spots = new List<Spot>();
    }
}