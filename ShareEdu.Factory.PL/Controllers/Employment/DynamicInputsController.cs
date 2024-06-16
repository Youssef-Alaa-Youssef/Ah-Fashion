using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShareEdu.Factory.BLL.Interfaces;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Employment;
using ShareEdu.Factory.PL.ViewModels.Employment;
using System;
using System.Threading.Tasks;

namespace ShareEdu.Factory.Controllers
{
    [Authorize]
    public class DynamicInputsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DynamicInputsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Employment(Guid JobId)
        {
            if (JobId != Guid.Empty) 
            {
                ViewBag.Jobs = await _unitOfWork.GetRepository<Jobs>().FindAsync(di => di.Id == JobId);
                var dynamicInputs = await _unitOfWork.GetRepository<DynamicInput>().FindAsync(di => di.JobId == JobId);
                return View(dynamicInputs);
            }

            var allDynamicInputs = await _unitOfWork.GetRepository<DynamicInput>().GetAllAsync();
            return View(allDynamicInputs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitDynamicForm(IEnumerable<DynamicInput> dynamicInputs)
        {
            // Process the submitted dynamic inputs as needed
            // Save to database, validate, etc.

            return RedirectToAction("Index", "Home"); // Redirect to success page or another action
        }

        public async Task<IActionResult> Index()
        {
            var dynamicInputs = await _unitOfWork.GetRepository<DynamicInput>().GetAllAsync();
            return View(dynamicInputs);
        }

        // GET: DynamicInputs/Create
        public async Task<IActionResult> Create()
        {
            var inputTypes = await _unitOfWork.GetRepository<InputType>().GetAllAsync();
            var jobs = await _unitOfWork.GetRepository<Jobs>().GetAllAsync();
            var jobCategories = await _unitOfWork.GetRepository<JobCategory>().GetAllAsync();

            ViewBag.InputTypes = inputTypes.Select(it => new SelectListItem
            {
                Value = it.Id.ToString(),
                Text = it.Name
            }).ToList();

            ViewBag.Jobs = jobs.Select(job => new SelectListItem
            {
                Value = job.Id.ToString(),
                Text = job.Title
            }).ToList();

            ViewBag.JobCategories = jobCategories.Select(cat => new SelectListItem
            {
                Value = cat.Id.ToString(),
                Text = cat.Name
            }).ToList();

            return View();
        }

        // POST: DynamicInputs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DynamicInputViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Create a new DynamicInput entity from viewModel
                var dynamicInput = new DynamicInput
                {
                    Label = viewModel.Label,
                    InputTypeId = viewModel.InputTypeId,
                    IsVisible = viewModel.IsVisible,
                    IsRequired = viewModel.IsRequired,
                    JobId = viewModel.JobId,
                    JobCategoryId = viewModel.JobCategoryId
                };

                // Check if viewModel has options to add
                if (viewModel.Options != null && viewModel.Options.Any())
                {
                    var optionRepository = _unitOfWork.GetRepository<Option>();

                    // Create and add each Option from viewModel to the database
                    foreach (var optionViewModel in viewModel.Options)
                    {
                        var option = new Option
                        {
                            Text = optionViewModel.Text,
                            Value = optionViewModel.Value,
                            DynamicInputId = dynamicInput.Id // Assign DynamicInputId to establish the relationship
                        };

                        await optionRepository.AddAsync(option);
                    }
                }

                // Add the DynamicInput entity itself to the database
                await _unitOfWork.GetRepository<DynamicInput>().AddAsync(dynamicInput);
                await _unitOfWork.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); // Replace with your actual action name
            }

            // If model state is not valid, retrieve input types, jobs, and job categories again for the view
            var inputTypes = await _unitOfWork.GetRepository<InputType>().GetAllAsync();
            var jobs = await _unitOfWork.GetRepository<Jobs>().GetAllAsync();
            var jobCategories = await _unitOfWork.GetRepository<JobCategory>().GetAllAsync();

            ViewBag.InputTypes = inputTypes.Select(it => new SelectListItem
            {
                Value = it.Id.ToString(),
                Text = it.Name
            }).ToList();

            ViewBag.Jobs = jobs.Select(job => new SelectListItem
            {
                Value = job.Id.ToString(),
                Text = job.Title
            }).ToList();

            ViewBag.JobCategories = jobCategories.Select(cat => new SelectListItem
            {
                Value = cat.Id.ToString(),
                Text = cat.Name
            }).ToList();

            return View(viewModel);
        }



        // GET: DynamicInputs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                        var inputTypes = await _unitOfWork.GetRepository<InputType>().GetAllAsync();
            var jobs = await _unitOfWork.GetRepository<Jobs>().GetAllAsync();
            var jobCategories = await _unitOfWork.GetRepository<JobCategory>().GetAllAsync();

            ViewBag.InputTypes = inputTypes.Select(it => new SelectListItem
            {
                Value = it.Id.ToString(), 
                Text = it.Name
            }).ToList();
            ViewBag.Jobs = jobs.Select(job => new SelectListItem
            {
                Value = job.Id.ToString(),
                Text = job.Title
            }).ToList();

            ViewBag.JobCategories = jobCategories.Select(cat => new SelectListItem
            {
                Value = cat.Id.ToString(),
                Text = cat.Name
            }).ToList();
            var dynamicInput = await _unitOfWork.GetRepository<DynamicInput>().GetByIdAsync(id.Value);
            if (dynamicInput == null)
            {
                return NotFound();
            }
            return View(dynamicInput);
        }

        // POST: DynamicInputs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DynamicInput dynamicInput)
        {
            if (id != dynamicInput.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.GetRepository<DynamicInput>().UpdateAsync(dynamicInput);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dynamicInput);
        }

        // GET: DynamicInputs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dynamicInput = await _unitOfWork.GetRepository<DynamicInput>().GetByIdAsync(id.Value);
            if (dynamicInput == null)
            {
                return NotFound();
            }

            return View(dynamicInput);
        }

        // POST: DynamicInputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dynamicInput = await _unitOfWork.GetRepository<DynamicInput>().GetByIdAsync(id);
            await _unitOfWork.GetRepository<DynamicInput>().RemoveAsync(dynamicInput);
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
