using System;
using System.Collections.Generic;
using System.Text;
using WorkInMobileFinal.Views;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class ParametrePageViewModel:BaseViewModel
    {
        public Command LogoutCommand { get; set; }
        public ParametrePageViewModel()
        {
            LogoutCommand = new Command(ExecuteLogoutCommand);
        }

        private async void ExecuteLogoutCommand(object obj)
        {
            var response = await MaterialDialog.Instance.ConfirmAsync("Etes-vous sûr de vouloir vous déconnectez?", "Déconnexion", "Déconnexion");
            if (response==true)
            {
                StorageHelpers.LiteDbHelper.DeleteUser();
                Application.Current.MainPage = new SplashScreen();
            }
        }
    }
}
