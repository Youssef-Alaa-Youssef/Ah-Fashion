using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Settings;
using ShareEdu.Factory.PL.ViewModels.Settings;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShareEdu.Factory.Controllers
{
    [Authorize(Roles = "Admin,Super Admin")]
    public class SettingGroupsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingGroupsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: SettingGroups
        public async Task<IActionResult> Index()
        {
            var settingGroups = await _unitOfWork.GetRepository<SettingGroup>().GetAllAsync();
            return View(settingGroups);
        }

        // GET: SettingGroups/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SettingGroups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SettingGroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var settingGroup = new SettingGroup
                {
                    Name = viewModel.Name,
                    LinkNameEn = viewModel.LinkNameEn,
                    LinkNameAr = viewModel.LinkNameAr,
                    Controller = viewModel.Controller,
                    Action = viewModel.Action,
                    Visable = viewModel.Visable,
                    ranking = viewModel.Ranking,
                    place = viewModel.Place
                };

                await _unitOfWork.GetRepository<SettingGroup>().AddAsync(settingGroup);
                await _unitOfWork.SaveChangesAsync();

                TempData["Success"] = "Setting Group added successfully.";
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: SettingGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingGroup = await _unitOfWork.GetRepository<SettingGroup>().GetByIdAsync(id.Value);
            if (settingGroup == null)
            {
                return NotFound();
            }

            var viewModel = new SettingGroupViewModel
            {
                Id = settingGroup.Id,
                Name = settingGroup.Name,
                LinkNameEn = settingGroup.LinkNameEn,
                LinkNameAr = settingGroup.LinkNameAr,
                Controller = settingGroup.Controller,
                Action = settingGroup.Action,
                Visable = settingGroup.Visable,
                Ranking = settingGroup.ranking,
                Place = settingGroup.place
            };

            return View(viewModel);
        }

        // POST: SettingGroups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SettingGroupViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var settingGroup = new SettingGroup
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    LinkNameEn = viewModel.LinkNameEn,
                    LinkNameAr = viewModel.LinkNameAr,
                    Controller = viewModel.Controller,
                    Action = viewModel.Action,
                    Visable = viewModel.Visable,
                    ranking = viewModel.Ranking,
                    place = viewModel.Place
                };

                try
                {
                    await _unitOfWork.GetRepository<SettingGroup>().UpdateAsync(settingGroup);
                    await _unitOfWork.SaveChangesAsync();
                    TempData["Success"] = "Setting Group updated successfully.";
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Error: {ex.Message}";
                }

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: SettingGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingGroup = await _unitOfWork.GetRepository<SettingGroup>().GetByIdAsync(id.Value);
            if (settingGroup == null)
            {
                return NotFound();
            }

            return View(settingGroup);
        }

        // POST: SettingGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var settingGroup = await _unitOfWork.GetRepository<SettingGroup>().GetByIdAsync(id);
            if (settingGroup == null)
            {
                return NotFound();
            }

            await _unitOfWork.GetRepository<SettingGroup>().RemoveAsync(settingGroup);
            await _unitOfWork.SaveChangesAsync();

            TempData["Success"] = "Setting Group deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
