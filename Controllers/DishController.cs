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

        public IActionResult List(string category)
        {
            IEnumerable<Dish> dishes;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                dishes = _dishRepository.AllDishes.OrderBy(p => p.DishId);
                currentCategory = "Todos los Platos";
            }
            else
            {
                dishes = _dishRepository.AllDishes.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.DishId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new DishListViewModel(dishes, _categoryRepository.AllCategories, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var dish = _dishRepository.GetDishById(id);
            if (dish == null)
                return NotFound();

            return View(dish);
        }
    }
}
