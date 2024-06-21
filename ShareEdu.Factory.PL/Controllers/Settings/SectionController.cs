using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Settings;
using System;
using System.Threading.Tasks;

namespace ShareEdu.Factory.Controllers
{
    [Authorize(Roles = "Admin,Super Admin")]
    public class SectionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SectionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Sections
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.GetRepository<Section>().GetAllAsync());
        }

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _unitOfWork.GetRepository<Section>().GetByIdAsync(id.Value);

            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // GET: Sections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sections/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Visable,CreatedAt")] Section section)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.GetRepository<Section>().AddAsync(section);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(section);
        }

        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _unitOfWork.GetRepository<Section>().GetByIdAsync(id.Value);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        // POST: Sections/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Section section)
        {
            if (id != section.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Success"] = "Sections Updated Successfully";
                    
                    await _unitOfWork.GetRepository<Section>().UpdateAsync(section);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Error"] = "Invalid Options";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(section);
        }

        // GET: Sections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _unitOfWork.GetRepository<Section>().GetByIdAsync(id.Value);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var section = await _unitOfWork.GetRepository<Section>().GetByIdAsync(Id);
            await _unitOfWork.GetRepository<Section>().RemoveAsync(section);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SectionExists(int id)
        {
            var section = await _unitOfWork.GetRepository<Section>().FindAsync(x => x.Id == id);
            return section != null;
        }

    }
}
