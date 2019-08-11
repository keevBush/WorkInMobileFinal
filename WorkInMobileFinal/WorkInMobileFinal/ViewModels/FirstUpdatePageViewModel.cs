using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkInMobileFinal.Models;
using WorkInMobileFinal.Services;
using WorkInMobileFinal.StorageHelpers;
using WorkInMobileFinal.Views;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class FirstUpdatePageViewModel:BaseViewModel
    {
        public PhoneAffichage Pays { get; set; }
        public PhoneAffichage Code { get; set; }
        public ObservableCollection<PhoneAffichage> PhonesList{ get; set; }
        public DemandeurIdentite DemandeurIdentite { get; set; }
        public Command SaveCommand { get; set; }
        public INavigation Navigation { get; set; }
        public FirstUpdatePageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.Pays = new PhoneAffichage();
            this.Code = new PhoneAffichage();
            this.SaveCommand = new Command(ExecuteSaveCommand);
            this.DemandeurIdentite = new DemandeurIdentite();
            this.PhonesList = new ObservableCollection<PhoneAffichage>(GetListOfCountry());
        }

        private async void ExecuteSaveCommand(object obj)
        {
            var loader = await MaterialDialog.Instance.LoadingDialogAsync("Contact du serveur ... ",Configurations.MaterialConfig.MaterialLoadingDialogConfiguration);
            DemandeurIdentite.Id = LiteDbHelper.CurrentUser.Id;
            DemandeurIdentite.Email = LiteDbHelper.CurrentUser.Email;
            DemandeurIdentite.Password = LiteDbHelper.CurrentUser.Password;
            DemandeurIdentite.Telephone = Code.DialCode + DemandeurIdentite.Telephone;
            DemandeurIdentite.Nationalite = Pays.CountryName;
            var data = DemandeurIdentite;
            try
            {
                await RestService.For<IBackendService>(Configurations.ServerConfig.Host).Update(JsonConvert.SerializeObject(DemandeurIdentite));
                LiteDbHelper.UpdateDataUser(DemandeurIdentite);
                await loader.DismissAsync();
                await Navigation.PushAsync(new HomePage());
                
            }
            catch (Exception e)
            {
                await loader.DismissAsync();
                if (e is Refit.ApiException)
                    await MaterialDialog.Instance.SnackbarAsync($"{((Refit.ApiException)e).Content}", 3000, Configurations.MaterialConfig.MaterialSnackbarConfiguration);
                else
                    await MaterialDialog.Instance.SnackbarAsync($"Erreur: {e.Message}", 3000, Configurations.MaterialConfig.MaterialSnackbarConfiguration);

            }

        }

        private IEnumerable<PhoneAffichage> GetListOfCountry()
        {
            var data = DependencyService.Get<Services.IAssetManager>().AssetContent;
            return JsonConvert.DeserializeObject<IEnumerable <PhoneAffichage>>(data);
        }
    }
}
