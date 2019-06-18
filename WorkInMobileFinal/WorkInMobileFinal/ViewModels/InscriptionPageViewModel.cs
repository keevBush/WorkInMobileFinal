using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class InscriptionPageViewModel:BaseViewModel
    {
        public Command NewUserCommand { get; set; }
        private INavigation navigation;


        public InscriptionPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            this.NewUserCommand = new Command(ExecuteNewUserCommand);
        }

        private async void ExecuteNewUserCommand(object obj)
        {
            var loader = await MaterialDialog.Instance.LoadingSnackbarAsync("Connexion en cours ...", Configurations.MaterialConfig.MaterialSnackbarConfiguration);
            try
            {
                await Task.Delay(5000);
                await loader.DismissAsync();
                Application.Current.MainPage = new NavigationPage(new Views.HomePage());
            }
            catch (Exception e)
            {
                await loader.DismissAsync();
                await MaterialDialog.Instance.SnackbarAsync("Error: " + e.Message, 3000, Configurations.MaterialConfig.MaterialSnackbarConfiguration);
            }
        }
    }
}
