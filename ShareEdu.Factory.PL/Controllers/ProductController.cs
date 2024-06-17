using Microsoft.AspNetCore.Mvc;

namespace ShareEdu.Factory.PL.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
