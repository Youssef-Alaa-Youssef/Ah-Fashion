using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Products;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShareEdu.Factory.Controllers
{
    [Authorize(Roles = "Admin, Super Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.GetRepository<Product>().GetAllAsync();
            return View(products);
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _unitOfWork.GetRepository<ProductCategory>().GetAllAsync();
            var sizes = await _unitOfWork.GetRepository<Size>().GetAllAsync();

            ViewBag.Categories = new SelectList(categories, "Id", "NameEn");
            ViewBag.Sizes = new SelectList(sizes, "SizeID", "NameEn");

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {

                await _unitOfWork.GetRepository<Product>().AddAsync(product);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var categories = await _unitOfWork.GetRepository<ProductCategory>().GetAllAsync();
            var sizes = await _unitOfWork.GetRepository<Size>().GetAllAsync();

            ViewBag.Categories = new SelectList(categories, "Id", "NameEn");
            ViewBag.Sizes = new SelectList(sizes, "SizeID", "NameEn");

            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var categories = await _unitOfWork.GetRepository<ProductCategory>().GetAllAsync();
            var sizes = await _unitOfWork.GetRepository<Size>().GetAllAsync();

            ViewBag.Categories = new SelectList(categories, "Id", "NameEn");
            ViewBag.Sizes = new SelectList(sizes, "SizeID", "NameEn");

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product viewModel)
        {
            if (id != viewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _unitOfWork.GetRepository<Product>().UpdateAsync(viewModel);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Error"] = "Invalid Options";
                }
                return RedirectToAction(nameof(Index));
            }

            var categories = await _unitOfWork.GetRepository<ProductCategory>().GetAllAsync();
            var sizes = await _unitOfWork.GetRepository<Size>().GetAllAsync();

            ViewBag.Categories = new SelectList(categories, "Id", "NameEn");
            ViewBag.Sizes = new SelectList(sizes, "SizeID", "NameEn");

            return View(viewModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _unitOfWork.GetRepository<Product>().FindAsync(p=>p.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<Product>().RemoveAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExists(int id)
        {
            var product = await _unitOfWork.GetRepository<Product>().FindAsync(e => e.ID == id);
            return product != null;
        }

    }
}
