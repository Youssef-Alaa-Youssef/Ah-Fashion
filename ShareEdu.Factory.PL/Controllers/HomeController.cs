using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Products;
using ShareEdu.Factory.DAL.Models.Settings;
using ShareEdu.Factory.PL.ViewModels;
using ShareEdu.Factory.PL.ViewModels.Home;
using System.Diagnostics;

namespace ShareEdu.Factory.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(UserManager<IdentityUser>  userManager,IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var section = await _unitOfWork.GetRepository<Section>().GetAllAsync();
            var sections = section.Where(x => x.SettingGroupId == 1).ToList(); 
            var website = await _unitOfWork.GetRepository<Website>().FindAsync(web => web.Id == 1);

            if (website != null)
            {
                bool isVisible = website.Select(w=>w.IsVisible).FirstOrDefault();
                if (!isVisible)
                {
                    return RedirectToAction("Issues");
                }
            }
            
            var categories = await _unitOfWork.GetRepository<ProductCategory>().GetAllAsync();
            ViewBag.Categories = categories.ToList();
            return View(sections);
        }
        public IActionResult Dashboard()
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
        public async Task<IActionResult> Issues()
        {
            var website = await _unitOfWork.GetRepository<Website>().FindAsync(web => web.Id == 1);

            if (website != null)
            {
                bool isVisible = website.Select(w => w.IsVisible).FirstOrDefault();
                if (isVisible)
                {
                    HttpContext.Response.Cookies.Append("WebsiteSetting", isVisible.ToString());

                    return RedirectToAction("Index");
                }
                
            }

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
