using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkInMobileFinal.Models;
using WorkInMobileFinal.StorageHelpers;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class SplashScreenViewModel:BaseViewModel
    {
        public bool IsLoading { get; set; }
        private INavigation Navigation { get; set; }
        public DemandeurIdentite CurrentUser { get; set; }
        public SplashScreenViewModel(INavigation navigation)
        {
            this.CurrentUser = LiteDbHelper.CurrentUser;
            this.Navigation = navigation;
            IsLoading = true;
            CheckUser();
        }
        public async Task CheckUser()
        {
            await Task.Delay(3500);
            if (SecureStorageHelper.AuthKey == null)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                if (string.IsNullOrEmpty(CurrentUser.Nom) ||
                    string.IsNullOrEmpty(CurrentUser.Postnom) ||
                    string.IsNullOrEmpty(CurrentUser.Prenom) ||
                    string.IsNullOrEmpty(CurrentUser.Username) ||
                    string.IsNullOrEmpty(CurrentUser.Telephone)
                    )
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        IsLoading = false;
                    });
                    await Navigation.PushAsync(new Views.FirstUpdatePage());
                }
                else
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        IsLoading = false;
                    });
                    App.Current.MainPage = new NavigationPage(new Views.HomePage());
                }
            }
        }
    }
}
