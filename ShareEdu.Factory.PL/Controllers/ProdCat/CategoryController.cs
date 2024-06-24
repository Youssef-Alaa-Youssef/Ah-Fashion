using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Products;
using ShareEdu.Factory.PL.Services.UploadFile;
using ShareEdu.Factory.PL.ViewModels;
using System.Threading.Tasks;

namespace ShareEdu.Factory.Controllers
{
    [Authorize(Roles = "Admin, Super Admin")]
    public class ProductCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ProductCategoryController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        // GET: ProductCategory
        public async Task<IActionResult> Index()
        {
            var categories = await _unitOfWork.GetRepository<ProductCategory>().GetAllAsync();
            return View(categories);
        }

        // GET: ProductCategory/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
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

        // GET: ProductCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var uploadedImagePath = await _fileService.UploadFileAsync(category.ImagePathFile);

                var newCategory = new ProductCategory
                {
                    NameAr = category.NameAr,
                    NameEn = category.NameEn,
                    Description = category.Description,
                    ImagePath = uploadedImagePath
                };

                await _unitOfWork.GetRepository<ProductCategory>().AddAsync(newCategory);
                await _unitOfWork.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // GET: ProductCategory/Edit/5// GET: ProductCategory/Edit/5
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

            var categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                NameEn = category.NameEn,
                NameAr = category.NameAr,
                Description = category.Description
                // You don't need to populate ImagePathFile here; it will be handled by the form submission
            };

            return View(categoryViewModel);
        }

        // POST: ProductCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Get the existing ProductCategory entity from database
                    var category = await _unitOfWork.GetRepository<ProductCategory>().GetByIdAsync(id);
                    if (category == null)
                    {
                        return NotFound();
                    }

                    // Update fields from ViewModel to Entity
                    category.NameEn = viewModel.NameEn;
                    category.NameAr = viewModel.NameAr;
                    category.Description = viewModel.Description;

                    // Handle file upload if a new file is provided
                    if (viewModel.ImagePathFile != null && viewModel.ImagePathFile.Length > 0)
                    {
                        // Upload the new image file
                        var uploadedImagePath = await _fileService.UploadFileAsync(viewModel.ImagePathFile);
                        // Update the ImagePath property of the category with the new file path
                        category.ImagePath = uploadedImagePath;
                    }

                    // Update the category entity in repository and save changes
                    await _unitOfWork.GetRepository<ProductCategory>().UpdateAsync(category);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductCategoryExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Handle exception as needed
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
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
            if (category == null)
            {
                return NotFound();
            }

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
