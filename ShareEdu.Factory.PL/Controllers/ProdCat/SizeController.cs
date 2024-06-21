using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Products;
using System.Linq;
using System.Threading.Tasks;

namespace ShareEdu.Factory.Controllers
{
    public class SizeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SizeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Size
        public async Task<IActionResult> Index()
        {
            var sizes = await _unitOfWork.GetRepository<Size>().GetAllAsync();
            return View(sizes);
        }

        // GET: Size/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Size/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Size size)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.GetRepository<Size>().AddAsync(size);
                await _unitOfWork.SaveChangesAsync();
                TempData["Success"] = "Size added successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(size);
        }

        // GET: Size/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size = await _unitOfWork.GetRepository<Size>().GetByIdAsync(id.Value);
            if (size == null)
            {
                return NotFound();
            }
            return View(size);
        }

        // POST: Size/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Size size)
        {
            if (id != size.SizeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.GetRepository<Size>().UpdateAsync(size);
                    await _unitOfWork.SaveChangesAsync();
                    TempData["Success"] = "Size updated successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SizeExists(size.SizeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(size);
        }

        // GET: Size/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var size = await _unitOfWork.GetRepository<Size>().GetByIdAsync(id.Value);
            if (size == null)
            {
                return NotFound();
            }

            return View(size);
        }

        // POST: Size/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var size = await _unitOfWork.GetRepository<Size>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<Size>().RemoveAsync(size);
            await _unitOfWork.SaveChangesAsync();
            TempData["Success"] = "Size deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        private bool SizeExists(int id)
        {
            return _unitOfWork.GetRepository<Size>().FindAsync(e => e.SizeID == id) != null;
        }
    }
}
