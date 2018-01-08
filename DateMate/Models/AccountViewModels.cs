using DateMate.Internationalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DateMate.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
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
        [Display(ResourceType = typeof(AppResources), Name = nameof(AppResources.Email))]
        public string Email { get; set; }

        [Required]
        [Display(ResourceType = typeof(AppResources), Name = nameof(AppResources.NickName))]
        public string NickName { get; set; }

        public string  UserName { get; set; }

        [Required]
        [Display(ResourceType = typeof(AppResources), Name = nameof(AppResources.Location))]
        public string Location { get; set; }

        [Required]
        [Display(ResourceType = typeof(AppResources), Name = nameof(AppResources.Fabric))]
        public string Fabric { get; set; }

        [Display(ResourceType = typeof(AppResources), Name = nameof(AppResources.UserPhoto))]
        public byte[] UserPhoto { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(AppResources), Name = nameof(AppResources.Password))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(AppResources), Name = nameof(AppResources.ConfirmPassword))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
