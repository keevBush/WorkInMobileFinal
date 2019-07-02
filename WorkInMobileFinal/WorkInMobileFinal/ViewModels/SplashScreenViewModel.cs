using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkInMobileFinal.StorageHelpers;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class SplashScreenViewModel:BaseViewModel
    {
        public bool IsLoading { get; set; }
        private INavigation Navigation { get; set; }
        public SplashScreenViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            IsLoading = true;
            CheckUser();
        }
        public async Task CheckUser()
        {
            if( SecureStorageHelper.AuthKey== null)
            {
                await Navigation.PushAsync (new MainPage());
            }
            else
            {
                await Navigation.PushAsync (new Views.FirstUpdatePage());
            }
        }
    }
}
