using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TouristGuide.Models
{
    public class District
    {
        [Required(ErrorMessage = "Field can not be empty")]
        [StringLength(4, MinimumLength = 1)]
        [Display(Name = "District Code")]
        public string DistrictCode { get; set; }

        [Key]
        [Required(ErrorMessage ="Field can not be empty")]
        [StringLength(30,MinimumLength =3)]
        [Display(Name ="District Name")]
        public string DistrictName { get; set; }

        [NotMapped]
        public List<District> Districts { get; set; }
    }
}