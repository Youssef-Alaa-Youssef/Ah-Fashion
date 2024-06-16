using System.ComponentModel.DataAnnotations;

namespace ShareEdu.Factory.PL.ViewModels.Auth
{
    public class LogInViewModel
    {
        [Required(ErrorMessage ="Please Provide Email Address")]
        [EmailAddress(ErrorMessage = "Please Provide Correct Email")]
        [Display(Name ="E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Provide Password")]
        [DataType(DataType.Password,ErrorMessage ="Please Provide Correct Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }


    }
}
