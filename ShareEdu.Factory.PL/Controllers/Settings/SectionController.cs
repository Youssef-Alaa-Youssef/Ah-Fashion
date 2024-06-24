using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Settings;
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
        public async Task<IActionResult> Create()
        {
            await PopulateSettingGroupsDropDownAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Visable,CreatedAt,SettingGroupId")] Section section)
        {
            await PopulateSettingGroupsDropDownAsync();

            if (ModelState.IsValid)
            {
                await _unitOfWork.GetRepository<Section>().AddAsync(section);
                await _unitOfWork.SaveChangesAsync();
                TempData["Success"] = "Section created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(section);
        }


        // GET: Sections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            await PopulateSettingGroupsDropDownAsync();

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Visable,CreatedAt,SettingGroupId")] Section section)
        {
            await PopulateSettingGroupsDropDownAsync();

            if (id != section.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.GetRepository<Section>().UpdateAsync(section);
                    await _unitOfWork.SaveChangesAsync();
                    TempData["Success"] = "Section updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Error"] = "Concurrency error occurred. Please try again.";
                }
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

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var section = await _unitOfWork.GetRepository<Section>().GetByIdAsync(id);
            if (section == null)
            {
                return NotFound();
            }

            await _unitOfWork.GetRepository<Section>().RemoveAsync(section);
            await _unitOfWork.SaveChangesAsync();
            TempData["Success"] = "Section deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateSettingGroupsDropDownAsync()
        {
            var settingGroups = await _unitOfWork.GetRepository<SettingGroup>().GetAllAsync();
            var rolesSelectList = new SelectList(settingGroups, "Id", "Name");
            ViewData["SettingGroups"] = rolesSelectList;
        }
    }
}
