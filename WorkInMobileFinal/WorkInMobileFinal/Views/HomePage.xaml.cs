using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkInMobileFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            var home = (TabbedPage)sender;
            title.Text = home.CurrentPage.Title;
        }

        private async void BtnMessagerie_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MessageriePage());
        }
    }
}