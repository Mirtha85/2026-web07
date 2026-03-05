using Microsoft.AspNetCore.Mvc;
using sistema_restaurante.Models;
using sistema_restaurante.ViewModels;

namespace sistema_restaurante.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishRepository _dishRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DishController(IDishRepository dishRepository, ICategoryRepository categoryRepository)
        {
            _dishRepository = dishRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            var dishListViewModel = new DishListViewModel(_dishRepository.AllDishes, "Nuestro Menú: Brasa y Tradición");
            return View(dishListViewModel);
        }
    }
}
