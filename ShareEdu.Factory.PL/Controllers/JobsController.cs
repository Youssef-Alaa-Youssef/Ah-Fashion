using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Employment;
using ShareEdu.Factory.PL.ViewModels;
using ShareEdu.Factory.PL.ViewModels.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareEdu.Factory.PL.Controllers
{
    [Authorize(Roles = "Admin,Super Admin,Recruitment Officer")]

    public class JobsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Job/AllJobs
        public async Task<IActionResult> AllJobs()
        {
            return View(await _unitOfWork.GetRepository<Jobs>().GetAllAsync());
        }
        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var job = await _unitOfWork.GetRepository<Jobs>().GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            var viewModel = new JobViewModel
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Salary = job.Salary,
                Responsibilities= job.Responsibilities,
                IsOpen = job.IsOpen,    
            };

            return View(viewModel);
        }

        // GET: Jobs/Create
        public async Task<IActionResult> Create()
        {
            var JobCategory = await _unitOfWork.GetRepository<JobCategory>().GetAllAsync();
            ViewBag.Categories = JobCategory.Select(it => new SelectListItem
            {
                Value = it.Id.ToString(),
                Text = it.Name
            }).ToList();
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var job = new Jobs
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Salary = viewModel.Salary,
                    Location = viewModel.Location,
                    CategoryId = viewModel.CategoryId, // Assign CategoryId, assuming it's an int
                    Responsibilities = viewModel.Responsibilities,
                    IsOpen = viewModel.IsOpen,
                };

                TempData["Success"] = "Jobs Created Successfully . ";
                await _unitOfWork.GetRepository<Jobs>().AddAsync(job);
                return RedirectToAction(nameof(Index));
            }
            var JobCategory = await _unitOfWork.GetRepository<JobCategory>().GetAllAsync();
            ViewBag.Categories = JobCategory.Select(it => new SelectListItem
            {
                Value = it.Id.ToString(),
                Text = it.Name
            }).ToList();
            TempData["Error"] = "Invalid Options";
            return View(viewModel);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var job = await _unitOfWork.GetRepository<Jobs>().GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            var viewModel = new JobViewModel
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Salary = job.Salary,
                Location = job.Location,
                Responsibilities=job.Responsibilities,
                IsOpen = job.IsOpen,

            };
            var JobCategory = await _unitOfWork.GetRepository<JobCategory>().GetAllAsync();
            ViewBag.Categories = JobCategory.Select(it => new SelectListItem
            {
                Value = it.Id.ToString(),
                Text = it.Name
            }).ToList();
            return View(viewModel);
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, JobViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var job = await _unitOfWork.GetRepository<Jobs>().GetByIdAsync(id);

                    if (job == null)
                    {
                        return NotFound();
                    }

                    // Update job entity properties
                    job.Title = viewModel.Title;
                    job.Description = viewModel.Description;
                    job.Salary = viewModel.Salary;
                    job.Location = viewModel.Location;
                    job.CategoryId = viewModel.CategoryId; // Assign CategoryId, assuming it's an int
                    job.Responsibilities = viewModel.Responsibilities;
                    job.IsOpen = viewModel.IsOpen;
                    TempData["Success"] = "Job Updated Successfully . ";
                    await _unitOfWork.GetRepository<Jobs>().UpdateAsync(job);
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Error"] = "Invalid Options";
                    if (!JobExists(viewModel.Id))
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
            return View(viewModel);
        }


        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var job = await _unitOfWork.GetRepository<Jobs>().GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            var viewModel = new JobViewModel
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Salary = job.Salary ,
                Location=job.Location,
                Responsibilities= job.Responsibilities
            };

            return View(viewModel);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            TempData["Success"] = "Job Deleted Successfully.";
            var job = await _unitOfWork.GetRepository<Jobs>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<Jobs>().RemoveAsync(job);
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(Guid id)
        {
            return _unitOfWork.GetRepository<Jobs>().GetByIdAsync(id) != null;
        }
    }
}
