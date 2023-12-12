using SQLite;

namespace Pizzarita
{
    

    public partial class App : Application
    {
        public static CartService CartService { get; } = new CartService();
        public App()
        {
            InitializeComponent();

           


            //MainPage = new ConfirmPage();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
