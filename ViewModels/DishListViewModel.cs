using sistema_restaurante.Models;

namespace sistema_restaurante.ViewModels
{
    public class DishListViewModel
    {
        public IEnumerable<Dish> Dishes { get; }
        public string? CurrentCategory { get; }

        public DishListViewModel(IEnumerable<Dish> dishes, string? currentCategory)
        {
            Dishes = dishes;
            CurrentCategory = currentCategory;
        }
    }
}
