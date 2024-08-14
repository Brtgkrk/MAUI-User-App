using BaseApp.Core.Entities;
using BaseApp.Core.Entities.ServerEntities.SchemaAuth;
using BaseApp.Core.ServerConnectivity;
using Supabase.Postgrest.Models;
using TrainingApp.ViewModels;

namespace TrainingApp.Pages.CorePages;

public partial class ProfilePage : ContentPage
{
    public Supabase.Gotrue.User? CurrentUser;
    public ProfilePage()
	{
		InitializeComponent();
        BindingContext = new ProfilePageViewModel();

        //CurrentUser = SupabaseService.SupabaseClient?.Auth?.CurrentUser;

        //// You need to manually notify the UI of the change
        //OnPropertyChanged(nameof(CurrentUser));
        //BindingContext = this;
    }

    private async void OnLogoutButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
}