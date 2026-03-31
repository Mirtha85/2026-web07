namespace sistema_restaurante.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Dish dish);
        int RemoveFromCart(Dish dish);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
