using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.DAL.Models.Auth;
using ShareEdu.Factory.DAL.Models.Employment;
using ShareEdu.Factory.PL.ViewModels.Auth;

namespace ShareEdu.Factory.Controllers
{
    [Authorize(Roles = "Super Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRoles> _roleManager;
        private readonly UserManager<IdentityUser> _userManager; // Assuming you have ApplicationUser defined

        public RoleController(RoleManager<ApplicationRoles> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = new List<ApplicationUserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userModel = new ApplicationUserViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles.ToList()
                };
                userViewModels.Add(userModel);
            }

            ViewBag.Roles = _roleManager.Roles
                .Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                })
                .ToList();

            return View(userViewModels);
        }
        public async Task<IActionResult> AllRoles(string query)
        {
            IQueryable<IdentityRole> rolesQuery = _roleManager.Roles; 

            if (!string.IsNullOrEmpty(query))
            {
                ViewBag.query = query;

                rolesQuery = rolesQuery.Where(r => r.Name.Contains(query));
            }
            var roles = await rolesQuery.ToListAsync();
            return View(roles);
        }
        // GET: Role/AssignRoles
        [HttpGet]
        public async Task<IActionResult> AssignRoles([FromQuery]string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new ApplicationUserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = await _userManager.GetRolesAsync(user) as List<string>
            };

            ViewBag.Roles = _roleManager.Roles
                .Select(r => new SelectListItem
                {
                    Value = r.Id,
                    Text = r.Name
                })
                .ToList();

            return View(viewModel);
        }

        // POST: Role/AssignRoles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRoles(ApplicationUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                TempData["Error"] = "Invalid Options";
                return NotFound();
            }

            // Remove all existing roles
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            TempData["Success"] = "Assign Role Added Successfuly.";
            // Add selected roles
            var rolesToAdd = await _roleManager.Roles.Where(r => model.Roles.Contains(r.Id)).ToListAsync();
            var result = await _userManager.AddToRolesAsync(user, rolesToAdd.Select(r => r.Name));

            if (!result.Succeeded)
            {
                TempData["Error"] = "Invalid Options";
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            return RedirectToAction(nameof(Index), "Role"); // Redirect to users list or appropriate action
        }   
        // GET: /Role/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationRoles role)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                TempData["Success"] = "Role Added Successfully.";
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                TempData["Error"] = "Invalid Options";
            }
            return View(role);
        }

        // GET: Role/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var roleViewModel = new ApplicationRolesViewModel
            {
                Id = role.Id,
                Name = role.Name,
                RoleNameAr = role.RoleNameAr // Assuming RoleNameAr is a property of ApplicationRoles
            };

            return View(roleViewModel);
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationRolesViewModel role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingRole = await _roleManager.FindByIdAsync(id);
                if (existingRole == null)
                {
                    return NotFound();
                }

                existingRole.Name = role.Name;
                existingRole.RoleNameAr = role.RoleNameAr; // Update RoleNameAr if needed

                var result = await _roleManager.UpdateAsync(existingRole);
                if (result.Succeeded)
                {
                    TempData["Success"] = "Role Updated Successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Invalid Options";
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(role);
        }
        // GET: /Role/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: /Role/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromForm]string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            // Check if there are any users assigned to this role
            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);

            if (usersInRole.Any())
            {
                ViewData["Error"] = "Cannot delete role with associated users.";
                return RedirectToAction(nameof(AllRoles));
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["Success"] = "Role Deleted Successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Error"] = "Invalid Options";
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(role);
        }



    }
}
