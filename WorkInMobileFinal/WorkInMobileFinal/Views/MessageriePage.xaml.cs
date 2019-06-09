using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageriePage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public MessageriePage()
        {
            InitializeComponent();
            lst.ItemsSource = new List<string> { "", "", "", "", "", "" };
           // LoadData();
            
        }

        private async void LoadData()
        {
            await MaterialDialog.Instance.AlertAsync(message: "This is an alert dialog",
                                    title: "Alert Dialog",
                                    acknowledgementText: "Got It");
        }
    }
}
