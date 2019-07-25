using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using WorkInMobileFinal.Extensions;
using WorkInMobileFinal.StorageHelpers;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        public string Email { get; set; }
        public string Pwd { get; set; }
        public Command LoginCommand { get; set; }
        private INavigation Navigation { get; set; }
        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.LoginCommand = new Command(ExecuteLoginCommand);
        }

        private async void ExecuteLoginCommand(object obj)
        {
            var loader = await MaterialDialog.Instance.LoadingDialogAsync("Contact du serveur ... ",Configurations.MaterialConfig.MaterialLoadingDialogConfiguration); 
            try
            {
               var currentUser = await RestService.For<Services.IBackendService>(Configurations.ServerConfig.Host).Connexion(JsonConvert.SerializeObject(new
                {
                    email = Email,
                    motDePasse = Pwd.HashPassword()
                }));
                SecureStorageHelper.AuthKey = currentUser.Id;
                LiteDbHelper.SaveDataUser(currentUser);
                await loader.DismissAsync();
                if (string.IsNullOrEmpty(currentUser.Nom) ||
                    string.IsNullOrEmpty(currentUser.Postnom) ||
                    string.IsNullOrEmpty(currentUser.Prenom) ||
                    string.IsNullOrEmpty(currentUser.Username))
                    await Navigation.PushAsync(new Views.FirstUpdatePage());
                else
                    await Navigation.PushAsync(new Views.HomePage());
            }
            catch (Exception e)
            {
                await loader.DismissAsync();
                if(e is Refit.ApiException )
                    await MaterialDialog.Instance.SnackbarAsync($"{((Refit.ApiException)e).Content}",3000,Configurations.MaterialConfig.MaterialSnackbarConfiguration);
                else
                    await MaterialDialog.Instance.SnackbarAsync($"Erreur: {e.Message}",3000,Configurations.MaterialConfig.MaterialSnackbarConfiguration);

            }
        }
    }
}