using System.ComponentModel.DataAnnotations;

namespace ShareEdu.Factory.PL.ViewModels.Auth
{
    public class RestPasswordViewModel
    {
        [Required(ErrorMessage = "Please Provide Email Address")]
        [EmailAddress(ErrorMessage = "Please Provide Correct Email")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }
}
