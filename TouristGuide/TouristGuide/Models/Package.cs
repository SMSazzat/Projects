using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TouristGuide.Models
{
    public class Package
    {
        public int Id { get; set; }

        [Display(Name = "Offer")]
        public string Offer { get; set; }

        [Required(ErrorMessage = "Field can not be empty")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field can not be empty")]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [NotMapped]
        public List<Package> Packages { get; set; }
    }
}