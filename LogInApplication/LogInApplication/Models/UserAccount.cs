using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogInApplication.Models
{
    public class UserAccount
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Please confirm password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public List<UserAccount> UserAccounts { get; set; }

    }
}