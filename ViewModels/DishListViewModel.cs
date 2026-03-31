using sistema_restaurante.Models;

namespace sistema_restaurante.ViewModels
{
    public class DishListViewModel
    {
        public IEnumerable<Dish> Dishes { get; }
        public IEnumerable<Category> Categories { get; }
        public string? CurrentCategory { get; }

        public DishListViewModel(IEnumerable<Dish> dishes, IEnumerable<Category> categories, string? currentCategory)
        {
            Dishes = dishes;
            Categories = categories;
            CurrentCategory = currentCategory;
        }
    }
}
