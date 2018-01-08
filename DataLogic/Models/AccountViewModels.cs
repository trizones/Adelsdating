using AdelsDating.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        [MaxLength(32)]
        public string Email { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [Display(Name = "Nickname")]
        [MaxLength(20)]
        public string Nickname { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        [RegularExpression(@"^[A-Ö]+[a-öA-Ö''-'\s]*$")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        [RegularExpression(@"^[A-Ö]+[a-öA-Ö''-'\s]*$")]
        public string Lastname { get; set; }

        [Display(Name = "ProfilePicture")]
        public byte[] ProfilePicture { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}