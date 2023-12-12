using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Pizzarita;

public partial class Cart_Pizza : ContentPage
{
    public ObservableCollection<CartItem> CartItems { get; set; }
    public double TotalPrice => CartItems.Sum(item => item.Pizza.Price * item.Quantity);
    public ICommand RemovePizzaCommand { get; private set; }

    public Cart_Pizza()
    {
        InitializeComponent();

        // Initialize RemovePizzaCommand
        RemovePizzaCommand = new Command<CartItem>(RemovePizza);

        // Get the cart items from the service
        var cartItems = App.CartService.GetCartItems();

        // Initialize CartItems with the cart items
        CartItems = new ObservableCollection<CartItem>(cartItems);

        BindingContext = this;
    }
    private async void RemovePizza(CartItem cartItemToRemove)
    {
        bool result = await DisplayAlert("Confirm Removal", $"Are you sure you want to remove {cartItemToRemove.Pizza.Name} from the cart?", "Yes", "No");

        if (result)
        {
            // Remove the selected pizza from CartItems
            CartItems.Remove(cartItemToRemove);
            App.CartService.RemoveFromCart(cartItemToRemove.Pizza);

            // Recalculate TotalPrice
            OnPropertyChanged(nameof(TotalPrice));

            // Show alert
            await DisplayAlert("Item Removed", $"{cartItemToRemove.Pizza.Name} has been removed from the cart.", "OK");
        }
    }



    private async void ConfirmOrder(object sender, EventArgs e)
    {
        // Show alert
        await DisplayAlert("Order Confirmed", "Your order has been confirmed. Thank you!", "OK");

        // Clear the cart
        App.CartService.ClearCart();

        // Refresh the UI by updating CartItems
        var cartItems = App.CartService.GetCartItems();
        CartItems = new ObservableCollection<CartItem>(cartItems);

        // Set TotalPrice to 0
        OnPropertyChanged(nameof(TotalPrice));

        // Notify the UI that the CartItems and TotalPrice properties have changed
        OnPropertyChanged(nameof(CartItems));
    }

    private async void CompleteOrder(object sender, EventArgs e)
    {
        // Check if PizzaList is empty
        if (CartItems == null || CartItems.Count == 0)
        {
            // Show alert that the cart is empty
            await DisplayAlert("Empty Cart", "Your cart is empty. Add pizzas to your cart before completing the order.", "OK");
        }
        else
        {
            // Navigate to the ConfirmPage
            await Navigation.PushAsync(new ConfirmPage());
        }
    }


    private async void OnPizzaCardTapped(object sender, EventArgs e)
    {
        if (sender is Frame pizzaCard && pizzaCard.BindingContext is Pizza selectedPizza)
        {
            // Navigate to the view_pizza page and pass the selected pizza as a parameter
            await Navigation.PushAsync(new view_pizza(selectedPizza));
        }
    }
}
