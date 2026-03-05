using Microsoft.AspNetCore.Mvc;

namespace sistema_restaurante.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
