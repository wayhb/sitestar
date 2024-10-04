using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWars.Domain;

namespace StarWars.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        // чтобы был доступ к нашим доменным объектам
        private readonly DataManager dataManager;   

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public ActionResult Index()
        {
            //вывод всех услуг на главную страницу админа
            return View(dataManager.CharacterItems.GetCharactersItems());
        }

    }
}
