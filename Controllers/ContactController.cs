using Microsoft.AspNetCore.Mvc;

namespace sistema_restaurante.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit()
        {
            // Simple submission simulation
            TempData["ContactMessage"] = "Gracias por contactarnos. Te responderemos pronto.";
            return RedirectToAction("Index");
        }
    }
}
