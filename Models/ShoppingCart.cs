using Microsoft.EntityFrameworkCore;

namespace sistema_restaurante.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly RestauranteDbContext _restauranteDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(RestauranteDbContext restauranteDbContext)
        {
            _restauranteDbContext = restauranteDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            var context = services.GetService<RestauranteDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        private Dish GetOrCreateDishInDb(Dish repositoryDish)
        {
            var dishInDb = _restauranteDbContext.Dishes
                .Include(d => d.Category)
                .SingleOrDefault(d => d.DishId == repositoryDish.DishId);

            if (dishInDb != null)
            {
                return dishInDb;
            }

            Category? categoryInDb = null;
            if (repositoryDish.Category != null)
            {
                categoryInDb = _restauranteDbContext.Categories
                    .SingleOrDefault(c => c.CategoryId == repositoryDish.Category.CategoryId);

                if (categoryInDb == null)
                {
                    categoryInDb = new Category
                    {
                        CategoryId = repositoryDish.Category.CategoryId,
                        CategoryName = repositoryDish.Category.CategoryName,
                        Description = repositoryDish.Category.Description
                    };
                    _restauranteDbContext.Categories.Add(categoryInDb);
                    _restauranteDbContext.SaveChanges();
                }
            }

            dishInDb = new Dish
            {
                DishId = repositoryDish.DishId,
                Name = repositoryDish.Name,
                ShortDescription = repositoryDish.ShortDescription,
                LongDescription = repositoryDish.LongDescription,
                Price = repositoryDish.Price,
                ImageUrl = repositoryDish.ImageUrl,
                ImageThumbnailUrl = repositoryDish.ImageThumbnailUrl,
                IsDishOfTheWeek = repositoryDish.IsDishOfTheWeek,
                InStock = repositoryDish.InStock,
                CategoryId = repositoryDish.Category?.CategoryId ?? 0,
                Category = categoryInDb ?? repositoryDish.Category!
            };

            _restauranteDbContext.Dishes.Add(dishInDb);
            _restauranteDbContext.SaveChanges();

            return dishInDb;
        }

        public void AddToCart(Dish dish)
        {
            var dishToUse = GetOrCreateDishInDb(dish);

            var shoppingCartItem =
                    _restauranteDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Dish.DishId == dishToUse.DishId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Dish = dishToUse,
                    Amount = 1
                };

                _restauranteDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _restauranteDbContext.SaveChanges();
        }

        public int RemoveFromCart(Dish dish)
        {
            var dishToUse = _restauranteDbContext.Dishes
                .Include(d => d.Category)
                .SingleOrDefault(d => d.DishId == dish.DishId);

            if (dishToUse == null)
            {
                return 0;
            }

            var shoppingCartItem =
                    _restauranteDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Dish.DishId == dishToUse.DishId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _restauranteDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _restauranteDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _restauranteDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Dish)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _restauranteDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _restauranteDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _restauranteDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _restauranteDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => (decimal)c.Dish.Price * c.Amount).Sum();
            return total;
        }
    }
}
