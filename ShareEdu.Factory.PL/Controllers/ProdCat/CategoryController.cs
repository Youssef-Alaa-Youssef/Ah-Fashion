using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Products;
using System.Threading.Tasks;

namespace ShareEdu.Factory.Controllers
{
    [Authorize(Roles = "Admin, Super Admin")]
    public class ProductCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: ProductCategory
        public async Task<IActionResult> Index()
        {
            var categories = await _unitOfWork.GetRepository<ProductCategory>().GetAllAsync();
            return View(categories);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            return  View();
        }
        // GET: ProductCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.GetRepository<ProductCategory>().AddAsync(category);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: ProductCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _unitOfWork.GetRepository<ProductCategory>().GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: ProductCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductCategory category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.GetRepository<ProductCategory>().UpdateAsync(category);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Error"] = "Invalid Options";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: ProductCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _unitOfWork.GetRepository<ProductCategory>().GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: ProductCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _unitOfWork.GetRepository<ProductCategory>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<ProductCategory>().RemoveAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductCategoryExists(int id)
        {
            var category = await _unitOfWork.GetRepository<ProductCategory>().FindAsync(e => e.Id == id);
            return category != null;
        }

    }
}
