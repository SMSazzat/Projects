﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TouristGuide.Models
{
    public class ShoppingMall
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field can not be empty")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field can not be empty")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Field can not be empty")]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Field can not be empty")]
        [Display(Name = "District")]
        [ForeignKey("District")]
        public string Dictrict { get; set; }

        public District District { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> DistrictSelectListItems { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [NotMapped]
        public List<ShoppingMall> ShoppingMalls { get; set; }
    }
}