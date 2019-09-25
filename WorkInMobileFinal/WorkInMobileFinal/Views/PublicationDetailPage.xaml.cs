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
    public partial class PublicationDetailPage : ContentPage
    {
        public PublicationDetailPage(Models.CustomDataNotifications data)
        {
            InitializeComponent();
            //BindingContext = new ViewModels.PublicationDetailPageViewModel(data);
        }
        public PublicationDetailPage(Models.Publication data)
        {
            InitializeComponent();
            //BindingContext = new ViewModels.PublicationDetailPageViewModel(data);
        }
    }
}