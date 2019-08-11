using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicationPage : ContentPage
    {
        public PublicationPage()
        {
            InitializeComponent();
        }

        private async void MaterialChip_ActionImageTapped(object sender, EventArgs e)
        {
            await MaterialDialog.Instance.AlertAsync("ok", "Titre");
        }
    }
}