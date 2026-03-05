namespace sistema_restaurante.Models
{
    public interface IDishRepository
    {
        IEnumerable<Dish> AllDishes { get; }
        IEnumerable<Dish> DishesOfTheWeek { get; }
        Dish? GetDishById(int dishId);
    }
}
