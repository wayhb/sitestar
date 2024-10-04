using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWars.Domain;
using StarWars.Domain.Entities;

namespace StarWars.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CharacterItemsController : Controller
	{
		private readonly DataManager dataManager;
	    private readonly IWebHostEnvironment hostingEnvironment;
		public CharacterItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
		{
			this.dataManager = dataManager;
			this.hostingEnvironment = hostingEnvironment;
		}

		public ActionResult Edit(Guid id)
		{
			var entity = id == default ? new CharacterItem() : dataManager.CharacterItems.GetCharacterItemById(id);
			return View(entity);
		}

		[HttpPost]
		public ActionResult Edit(CharacterItem model, IFormFile	titleImageFile)
		{
			if(ModelState.IsValid)
			{
				if(titleImageFile != null)
				{
					model.TitleImagePath = titleImageFile.FileName;
					using(var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath,
						"images/", titleImageFile.FileName), FileAccess))
					{
						titleImageFile.CopyTo(stream);
					}

				}
				dataManager.CharacterItems.SaveCharacterItem(model);
				return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
			}
			return View(model);
		}

		[HttpPost]
		public ActionResult Delete(Guid id)
		{
			dataManager.CharacterItems.DeleteCharacterItem(id);
			return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());

		}


	}
}
