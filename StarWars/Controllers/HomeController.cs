using Microsoft.AspNetCore.Mvc;

namespace StarWars.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
