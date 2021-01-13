using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TouristGuide.Models
{
    public class RescueTeam
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Field can not be empty")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Name")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Contact no should be 6-11 digit")]
        [StringLength(11, MinimumLength = 6)]
        [Display(Name = "Contact")]
        public string Contact { set; get; }

        [Required(ErrorMessage = "Field can not be empty")]
        [Display(Name = "District")]
        [ForeignKey("District")]
        public string Dictrict { get; set; }

        public District District { get; set; }

        [NotMapped]
        public List<RescueTeam> RescueTeams { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem> DistrictSelectListItems { get; set; }
    }
}