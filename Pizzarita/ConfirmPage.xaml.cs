namespace Pizzarita
{
    public partial class ConfirmPage : ContentPage
    {
        // Your existing properties for data binding
        public string UserName { get; set; } = "";
        public string Address { get; set; } = "";
        public string Telephone { get; set; } = "";

        public ConfirmPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnConfirmOrderClicked(object sender, EventArgs e)
        {
            // Validate if required fields are not empty
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Address) || string.IsNullOrEmpty(Telephone))
            {
                await DisplayAlert("Error", "All fields are required.", "OK");
            }
            else if (!IsNumeric(Telephone))
            {
                await DisplayAlert("Error", "Telephone must be a numeric value.", "OK");
            }
            else
            {
                // Show an alert with the entered data
                await DisplayAlert("Order Confirmed", $"Name: {UserName}\nAddress: {Address}\nTelephone: {Telephone}", "OK");
                // Navigate to the CartPage
                // Get the cart items from the service
                App.CartService.ClearCart();
                await Navigation.PushAsync(new MainPage());
            }
        }

        private bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }
    }
}
