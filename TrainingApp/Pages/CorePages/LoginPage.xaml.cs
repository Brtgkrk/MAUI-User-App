using BaseApp.Core.ServerConnectivity;
using Microsoft.Maui.ApplicationModel.Communication;
//using TrainingApp.Models.Server.Core;
using TrainingApp.Pages.CorePages;

namespace TrainingApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string identity = IdentityEntry.Text;
            string password = PasswordEntry.Text;

            // Login user and create new session
            try
            {
                if (await Authorization.SignIn(identity, password))
                {
                    //Navigate to the HomePage
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
                else
                {

                    // TODO: Credentials invalid, throw message
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", $"{ex.Message}", "OK");
            }


            //Temp register new user
            //var session = await SupabaseService.SupabaseClient.Auth.SignUp("jakub.robert.krok.com", "P@ssword123");

            // TODO: Check if email and password exist and looks valid

            //if (await Authorization.Authorize(username, password))
            //{
            //    // Navigate to the HomePage
            //    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            //}
            //else
            //{
            //    // TODO: Credentials invalid, throw message
            //}
        }
    }

}
