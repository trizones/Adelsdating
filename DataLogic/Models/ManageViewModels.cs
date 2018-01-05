using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Web.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} måste vara åtminstone {2} tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nytt Lösenord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Verifiera nytt lösenord")]
        [Compare("NewPassword", ErrorMessage = "De två lösenorden matchar inte med varandra.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "´Nuvarande Lösenord")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "{0} måste vara åtminstone {2} tecken långt.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nytt Lösenord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Verifiera nytt lösenord.")]
        [Compare("NewPassword", ErrorMessage = "Det två lösenorden matchar inte med varandra.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangeNicknameModel
    {
        [Required]
        [Display(Name = "Nytt Smeknamn")]
        [MaxLength(20)]
        public string NewNickname { get; set; }

    }

    public class ChangeProfilePictureModel
    { 
    
        [Display(Name = "ProfilePicture")]
        public byte[] ProfilePicture { get; set; }
    }

    public class ChangeSearchable
    {
        [Display(Name = "Searchable")]
        public bool Searchable { get; set; }
    }

}