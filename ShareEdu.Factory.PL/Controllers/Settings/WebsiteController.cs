using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Settings;

namespace ShareEdu.Factory.Controllers
{
    [Authorize(Roles = "Super Admin")] 
    public class WebsiteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WebsiteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var websites = await _unitOfWork.GetRepository<Website>().GetAllAsync();
            return View(websites);
        }

 
        public async Task<IActionResult> Edit(int id)
        {
            var website = await _unitOfWork.GetRepository<Website>().GetByIdAsync(id);
            if (website == null)
            {
                return NotFound();
            }
            return View(website);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Website website)
        {
            if (id != website.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                Response.Cookies.Append("WebsiteVisibility", website.IsVisible.ToString());

                await _unitOfWork.GetRepository<Website>().UpdateAsync(website);
                await _unitOfWork.SaveChangesAsync();
                TempData["Success"] = "Website updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(website);
        }
    }
}
