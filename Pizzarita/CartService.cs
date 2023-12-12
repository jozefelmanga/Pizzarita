namespace Pizzarita
{
    public class CartItem
    {
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }
    }

    public class CartService
    {
        private List<CartItem> CartItems { get; set; }

        public CartService()
        {
            CartItems = new List<CartItem>();
        }

        public void AddToCart(Pizza pizza, int quantity)
        {
            var existingCartItem = CartItems.FirstOrDefault(item => item.Pizza == pizza);

            if (existingCartItem != null)
            {
                // If the pizza already exists in the cart, update the quantity
                existingCartItem.Quantity += quantity;
            }
            else
            {
                // If the pizza is not in the cart, add a new cart item
                CartItems.Add(new CartItem { Pizza = pizza, Quantity = quantity });
            }
        }

        public void RemoveFromCart(Pizza pizza)
        {
            var existingCartItem = CartItems.FirstOrDefault(item => item.Pizza == pizza);

            if (existingCartItem != null)
            {
                // If the pizza is in the cart, remove it
                CartItems.Remove(existingCartItem);
            }
        }

        public void ClearCart()
        {
            CartItems.Clear();
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems;
        }
    }
}
