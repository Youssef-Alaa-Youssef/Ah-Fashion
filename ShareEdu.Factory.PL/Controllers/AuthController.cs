using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ShareEdu.Factory.PL.Helper;
using ShareEdu.Factory.PL.Services.Email;
using ShareEdu.Factory.PL.ViewModels.Auth;
using System.Security.Claims;

namespace ShareEdu.Factory.PL.Controllers
{
    public class AuthController : Controller
    {
        private readonly EmailConfiguration _emailconfig;
        private readonly IWebHostEnvironment _environment;
        private readonly IEmailService _emailService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(EmailConfiguration emailconfig,IWebHostEnvironment environment,IEmailService EmailService, UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _emailconfig = emailconfig;
            _environment = environment;
            _emailService = EmailService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync<IdentityUser>();

            var userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var viewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName
                };

                userViewModels.Add(viewModel);
            }

            return View(userViewModels);
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInViewModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Error"] = "Invalid Email Or Password.";
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                TempData["Success"] = "Congratulations Login Successfully";
                return RedirectToAction(nameof(Index), "Home");
            }
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError(string.Empty, "Your account needs to be activated.");
                ModelState.AddModelError(string.Empty, "Please check your email for the activation link.");
                return View(model);
            }
            TempData["Error"] = "Invalid Email Or Password.";
            return View(model);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                TempData["Error"] = "Email is already in use.";
                return View(model);
            }

            var newUser = new IdentityUser { PhoneNumber = model.PhoneNumber, UserName = model.UserName, Email = model.Email }; // Adjust this line based on your ApplicationUser model
            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var confirmationLink = Url.Action("ConfirmEmail", "Auth",
                new { userId = newUser.Id, token = token }, Request.Scheme);
                string subject = "Activate Your Account";

                // HTML body of the email
                string body = $@"
                        <html>
                        <head>
                            <style>
                                body {{
                                    font-family: Arial, sans-serif;
                                    line-height: 1.6;
                                    background-color: #f7f7f7;
                                    padding: 20px;
                                }}
                                .container {{
                                    max-width: 600px;
                                    margin: 0 auto;
                                    background-color: #fff;
                                    padding: 30px;
                                    border-radius: 5px;
                                    box-shadow: 0 0 10px rgba(0,0,0,0.1);
                                }}
                                .btn {{
                                    display: inline-block;
                                    background-color: #007bff;
                                    color: #fff;
                                    text-decoration: none;
                                    padding: 10px 20px;
                                    border-radius: 5px;
                                }}
                            </style>
                        </head>
                        <body>
                            <div class='container'>
                                <h2>Hello, {newUser.UserName}</h2>
                                <p>Thank you for registering with us. Please click the button below to activate your account:</p>
                                <p><a class='btn' href='{confirmationLink}'>Activate Account</a></p>
                                <p>If you did not register with us, you can ignore this email.</p>
                                <p>Best regards,<br>{_emailconfig.DisplayName} Application Team</p>
                            </div>
                        </body>
                        </html>
                    ";

                await _emailService.SendEmailAsync(newUser.Email, subject, body);


                return RedirectToAction(nameof(Confirmation));
            }

            foreach (var error in result.Errors)
            {
                TempData["Error"] = $"{error.Description}.";

                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "Please provide valid credentials.";

                return RedirectToAction("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                TempData["Success"] = "Account Activated Successfully.";
                return RedirectToAction("Activated");
            }

            return RedirectToAction("Error");
        }
        public IActionResult Activated()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            TempData["Success"] = "You have been successfully logged out";
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); 
        }
        [HttpGet]
        public IActionResult RestPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestPassword(RestPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    TempData["Error"] = "Account Not Activated";
                    return RedirectToAction(nameof(ForgetPass));
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ActualRestPassword", "Auth", new { userId = user.Id, token }, protocol: HttpContext.Request.Scheme);
                string subject = "Reset Your Password";
                string body = $@"
                <html>
                <head>
                    <style>
                        body {{
                            font-family: Arial, sans-serif;
                            line-height: 1.6;
                            background-color: #f7f7f7;
                            padding: 20px;
                        }}
                        .container {{
                            max-width: 600px;
                            margin: 0 auto;
                            background-color: #fff;
                            padding: 30px;
                            border-radius: 5px;
                            box-shadow: 0 0 10px rgba(0,0,0,0.1);
                        }}
                        .btn {{
                            display: inline-block;
                            background-color: #007bff;
                            color: #fff;
                            text-decoration: none;
                            padding: 10px 20px;
                            border-radius: 5px;
                        }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h2>Hello, {user.UserName}</h2>
                        <p>We received a request to reset your password. Click the button below to reset it:</p>
                        <p><a class='btn' href='{callbackUrl}'>Reset Password</a></p>
                        <p>If you did not request a password reset, you can ignore this email.</p>
                        <p>Best regards,<br>{_emailconfig.DisplayName} Application Team</p>
                    </div>
                </body>
                </html>
            ";

                await _emailService.SendEmailAsync(user.Email, subject, body);
                return RedirectToAction(nameof(ForgetPass));
            }

            return View(model);
        }

        public IActionResult ForgetPass()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ActualRestPassword(string UserId, string Token)
        {
            if (UserId == null || Token == null)
            {
                TempData["Error"] = "Please provide valid credentials.";
                return RedirectToAction(nameof(RestPassword));
            }

            var model = new ActualRestPassswordViewModel { UserId = UserId, Token = Token };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualRestPassword(ActualRestPassswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    TempData["Error"] = "Please provide valid credentials.";

                    return RedirectToAction(nameof(RestPassword));
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    TempData["Success"] = "Reset Password Done Successfully. ";

                    return RedirectToAction(nameof(ResetPasswordConfirmation));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        TempData["Error"] = $"{error.Description}.";
                    }
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public IActionResult AccessDenied()
            {
                return View();
            }

        }
}
