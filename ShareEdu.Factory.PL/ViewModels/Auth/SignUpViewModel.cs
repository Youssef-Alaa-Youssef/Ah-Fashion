using System.ComponentModel.DataAnnotations;

namespace ShareEdu.Factory.PL.ViewModels.Auth
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Please Provide UserName")]
        [MinLength(5, ErrorMessage = "UserName  Must be at least 5 characters")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Provide PhoneNumber")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Please Provide Email Address")]
        [EmailAddress(ErrorMessage = "Please Provide Correct Email")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Provide Password")]
        [DataType(DataType.Password,ErrorMessage ="Please Provide Correct Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
