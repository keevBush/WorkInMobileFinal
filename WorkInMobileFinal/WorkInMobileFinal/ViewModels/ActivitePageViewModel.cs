using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class ActivitePageViewModel:BaseViewModel
    {
        public Command ParticiperCommand { get; set; }
        public ActivitePageViewModel()
        {
            this.ParticiperCommand = new Command(ExecuteParticiperCommand);
        }

        private async void ExecuteParticiperCommand(object obj)
        {
            await MaterialDialog.Instance.SnackbarAsync("En contact du serveur ...", "OK",3000,Configurations.SnackBarConfig.MaterialSnackbarConfiguration);
        }
    }
}
