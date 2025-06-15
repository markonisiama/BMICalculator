namespace BMICalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InputPage())
            {
                BarTextColor = Colors.Black
            };
        }
    }
}
