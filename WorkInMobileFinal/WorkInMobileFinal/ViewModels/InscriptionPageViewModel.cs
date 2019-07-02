using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkInMobileFinal.Extensions;
using WorkInMobileFinal.Models;
using WorkInMobileFinal.Services;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class InscriptionPageViewModel:BaseViewModel
    {
        public Command NewUserCommand { get; set; }
        public string Pwd { get; set; }
        public bool IsError { get;set; }
        public string PwdConfirm { get; set; }
        private INavigation navigation;
        public DemandeurIdentite DemandeurIdentite { get; set; }

        public InscriptionPageViewModel(INavigation navigation)
        {
            this.DemandeurIdentite = new DemandeurIdentite();
            this.navigation = navigation;
            this.NewUserCommand = new Command(ExecuteNewUserCommand);
        }
        private async void ExecuteNewUserCommand(object obj)
        {
            this.DemandeurIdentite.Id = Guid.NewGuid().ToString();
            var loader = await MaterialDialog.Instance.LoadingDialogAsync("Veuillez patienter svp ...");
            try
            {
                if (PwdConfirm.Trim() != Pwd.Trim())
                    throw new Exception("Mot de passe saisi ne correspond pas");
                if (IsError)
                    throw new Exception("Verifiez vos données");
                this.DemandeurIdentite.Password = Pwd.HashPassword();
                await RestService.For<IBackendService>(Configurations.ServerConfig.Host).Inscription(JsonConvert.SerializeObject(this.DemandeurIdentite));
                await loader.DismissAsync();
                await MaterialDialog.Instance.AlertAsync($"Un e-mail de verification a été envoyé à {this.DemandeurIdentite.Email}");
            }
            catch (Exception e)
            {
                await loader.DismissAsync();
                await MaterialDialog.Instance.SnackbarAsync("Error: " + e.Message, 3000, Configurations.MaterialConfig.MaterialSnackbarConfiguration);
            }
        }
    }
}
