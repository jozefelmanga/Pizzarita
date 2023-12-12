namespace Pizzarita
{
    public partial class view_pizza : ContentPage
    {
        private Pizza pizzaInstance;
        private int quantity = 1; // Initial quantity

        private double originalPrice;
        public view_pizza(Pizza selectedPizza)
        {
            InitializeComponent();

            // Create an instance of Pizza and set its properties
            pizzaInstance = new Pizza
            {
                Name = selectedPizza?.Name,
                Description = selectedPizza?.Description,
                Ingredients = selectedPizza?.Ingredients,
                Price = (double)(selectedPizza?.Price),
                Size="Medium",
                ImageUrl = selectedPizza?.ImageUrl
            };
            // Store the original price locally
            originalPrice = pizzaInstance.Price;

           



            // Set the BindingContext to the pizza instance
            BindingContext = pizzaInstance;

        
          
        }

        private async void OnAddToCartClicked(object sender, EventArgs e)
        {
            // Assuming you have a reference to the selected pizza in your page
            if (pizzaInstance != null)
            {
                // Add the selected pizza to the cart with the current quantity
                App.CartService.AddToCart(pizzaInstance, quantity);
                // Display a confirmation or update UI as needed
                await DisplayAlert("Added to Cart", $"{pizzaInstance.Name} added to your cart", "OK");
                // Navigate to the CartPage
                await Navigation.PushAsync(new MainPage());
            }
        }

        private void OnMinusClicked(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                UpdateQuantityLabel();
            }
        }

        private void OnPlusClicked(object sender, EventArgs e)
        {
            quantity++;
            UpdateQuantityLabel();
        }

        private void UpdateQuantityLabel()
        {
            QuantityLabel.Text = quantity.ToString();
        }

        // Event handler for size selection changed
        private void OnPizzaSizeChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = (RadioButton)sender;

            if (radioButton?.BindingContext is Pizza pizza && pizza != null)
            {
                
                // Adjust the price based on the selected size
                if (radioButton == SmallPizzaRadioButton)
                {
                    pizza.Size = "Small";
                    pizza.Price = originalPrice * 0.9;
                }
                else if (radioButton == MediumPizzaRadioButton)
                {
                    pizza.Size = "Medium";
                    pizza.Price = originalPrice * 1;
                }
                else if (radioButton == LargePizzaRadioButton)
                {
                    pizza.Size = "Large";
                    pizza.Price = originalPrice * 1.2;
                }

                // Update the displayed price in the UI
                OnPropertyChanged(nameof(pizza.Price));
            }
        }

    }
}
