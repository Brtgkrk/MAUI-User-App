using BaseApp.Core.ServerConnectivity;
using CommunityToolkit.Mvvm.ComponentModel;
using Supabase.Gotrue;
using System.ComponentModel;

namespace TrainingApp.ViewModels;

public partial class ProfilePageViewModel : ObservableObject
{
    public ProfilePageViewModel()
    {
        //currentUser = new User();
        //currentUser.Email = "lolxd@xd.xd";
        CurrentUser = SupabaseService.SupabaseClient?.Auth?.CurrentUser;
        Username = "current username 1";
    }

    [ObservableProperty]
    public User? currentUser;

    [ObservableProperty]
    public string username;

    //public User? CurrentUser
    //{
    //    get => CurrentUser;
    //    set
    //    {
    //        CurrentUser = value;
    //        OnPropertyChanged(nameof(CurrentUser));
    //    }
    //}

    //public event PropertyChangedEventHandler? PropertyChanged;
    //void OnPropertyChanged(string name) =>
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
