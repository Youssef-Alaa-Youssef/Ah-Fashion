using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Auth;
using ShareEdu.Factory.DAL.Models.Settings;
using ShareEdu.Factory.PL.ViewModels.Settings;

namespace ShareEdu.Factory.Controllers
{
    [Authorize(Roles = "Admin,Super Admin")]
    public class SettingGroupsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<ApplicationRoles> _roleManager;

        public SettingGroupsController(IUnitOfWork unitOfWork, RoleManager<ApplicationRoles> roleManager)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
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
            var roles = await _roleManager.Roles.ToListAsync();
            var rolesSelectList = new SelectList(roles, nameof(IdentityRole.NormalizedName), nameof(IdentityRole.Name));
            ViewData["Roles"] = rolesSelectList;

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
                    place = viewModel.Place,
                    Permission = viewModel.Permission,
                };

                await _unitOfWork.GetRepository<SettingGroup>().AddAsync(settingGroup);
                await _unitOfWork.SaveChangesAsync();

                TempData["Success"] = "Setting Group added successfully.";
                return RedirectToAction(nameof(Index));
            }
                var roles = await _roleManager.Roles.ToListAsync();
                var rolesSelectList = new SelectList(roles, nameof(IdentityRole.NormalizedName), nameof(IdentityRole.Name));
                ViewData["Roles"] = rolesSelectList;

            return View(viewModel);
        }

        // GET: SettingGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var roles = await _roleManager.Roles.ToListAsync();
            var rolesSelectList = new SelectList(roles, nameof(IdentityRole.NormalizedName), nameof(IdentityRole.Name));
            ViewData["Roles"] = rolesSelectList;
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
                Place = settingGroup.place,
                Permission = settingGroup.Permission,
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
            var roles = await _roleManager.Roles.ToListAsync();
            var rolesSelectList = new SelectList(roles, nameof(IdentityRole.NormalizedName), nameof(IdentityRole.Name));
            ViewData["Roles"] = rolesSelectList;

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
                    place = viewModel.Place,
                    Permission = viewModel.Permission,
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
