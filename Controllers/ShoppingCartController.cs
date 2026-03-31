using sistema_restaurante.Models;
using sistema_restaurante.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace sistema_restaurante.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IDishRepository _dishRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IDishRepository dishRepository, IShoppingCart shoppingCart)
        {
            _dishRepository = dishRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int dishId)
        {
            var selectedDish = _dishRepository.AllDishes.FirstOrDefault(p => p.DishId == dishId);

            if (selectedDish != null)
            {
                _shoppingCart.AddToCart(selectedDish);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int dishId)
        {
            var selectedDish = _dishRepository.AllDishes.FirstOrDefault(p => p.DishId == dishId);

            if (selectedDish != null)
            {
                _shoppingCart.RemoveFromCart(selectedDish);
            }
            return RedirectToAction("Index");
        }
    }
}
