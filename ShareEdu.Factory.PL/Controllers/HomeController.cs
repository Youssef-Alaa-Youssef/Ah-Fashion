using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using ShareEdu.Factory.PL.ViewModels;
using ShareEdu.Factory.PL.ViewModels.Home;
using System.Diagnostics;

namespace ShareEdu.Factory.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(UserManager<IdentityUser>  userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult ContactUs()
        {

            return View();
        }
        public IActionResult AboutUs()
        {

            return View();
        }
        public IActionResult FAQS()
        {
            return View();
        }
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new ProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = await GetRoleName(user) 
            };

            return View(viewModel);
        }

        private async Task<string> GetRoleName(IdentityUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ErrorProd()
        {
            return View();
        }
    }
}
