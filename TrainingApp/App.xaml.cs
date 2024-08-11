namespace TrainingApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Initialize new Appshell and go to login page
            MainPage = new AppShell();
            Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
