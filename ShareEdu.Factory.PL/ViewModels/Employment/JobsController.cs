using Microsoft.AspNetCore.Mvc;
using ShareEdu.Factory.BLL.InterFaces;
using ShareEdu.Factory.DAL.Models.Employment;

namespace ShareEdu.Factory.PL.ViewModels.Employment
{
    public class JobsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var jobCategories = await _unitOfWork.GetRepository<JobCategory>().GetAllAsync();
            return View(jobCategories);
        }
    }

}
