using System.Collections.ObjectModel;

namespace Pizzarita
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Pizza> PizzaList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Populate PizzaList with static data
            PizzaList = new ObservableCollection<Pizza>
            {
            new Pizza { Name = "Margherita", Description = "Classic tomato and cheese", Ingredients = "Tomato, Mozzarella, Basil", Price = 8.99, ImageUrl = "./Resources/Images/margherita.png" },
            new Pizza { Name = "Pepperoni", Description = "Pepperoni and cheese", Ingredients = "Pepperoni, Mozzarella, Tomato Sauce", Price = 10.99, ImageUrl = "./Resources/Images/pepperoni.png" },
            new Pizza { Name = "Vegetarian", Description = "Assorted veggies and cheese", Ingredients = "Bell Peppers, Mushrooms, Olives, Onion, Mozzarella", Price = 9.99, ImageUrl = "./Resources/Images/vegetarian.png" },
            new Pizza { Name = "BBQ Chicken", Description = "Grilled chicken, BBQ sauce, and cheese", Ingredients = "Grilled Chicken, BBQ Sauce, Red Onion, Mozzarella", Price = 12.99, ImageUrl = "./Resources/Images/bbq_chicken.png" },
            new Pizza { Name = "Hawaiian", Description = "Ham, pineapple, and cheese", Ingredients = "Ham, Pineapple, Mozzarella", Price = 11.99, ImageUrl = "./Resources/Images/hawaiian.png" },
            new Pizza { Name = "Mushroom Delight", Description = "Mushrooms, garlic, and cheese", Ingredients = "Mushrooms, Garlic, Mozzarella", Price = 10.49, ImageUrl = "./Resources/Images/mushroom_delight.png" },
            new Pizza { Name = "Supreme", Description = "Pepperoni, sausage, veggies, and cheese", Ingredients = "Pepperoni, Sausage, Bell Peppers, Onions, Mozzarella", Price = 13.99, ImageUrl = "./Resources/Images/supreme.png" },
            new Pizza { Name = "Spinach and Feta", Description = "Spinach, feta cheese, and garlic", Ingredients = "Spinach, Feta Cheese, Garlic, Mozzarella", Price = 11.49, ImageUrl = "./Resources/Images/spinach_and_feta.png" },
            new Pizza { Name = "BBQ Beef", Description = "Savory barbecue beef with onions", Ingredients = "Barbecue Beef, Onions, Mozzarella", Price = 12.49, ImageUrl = "./Resources/Images/bbq_beef.png" },
            };

            BindingContext = this;
        }
        private async void OnPizzaSelected(object sender, SelectionChangedEventArgs e)
        {
            // Display an alert with the specified message
            await DisplayAlert("Alert", "Here from selected", "OK");

            // Reset the selection
            ((CollectionView)sender).SelectedItem = null;
        }

        private async void OnPizzaCardTapped(object sender, EventArgs e)
        {
            if (sender is Frame pizzaCard && pizzaCard.BindingContext is Pizza selectedPizza)
            {
             
                // Navigate to the view_pizza page and pass the selected pizza as a parameter
                await Navigation.PushAsync(new view_pizza(selectedPizza));
            }
        }

        private async void OnShoppingCartClicked(object sender, EventArgs e)
        {
            // Navigate to the CartPage
            await Navigation.PushAsync(new Cart_Pizza());
        }






    }

}
