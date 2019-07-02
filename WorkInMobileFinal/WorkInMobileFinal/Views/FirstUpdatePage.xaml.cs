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
    public partial class FirstUpdatePage : ContentPage
    {
        public FirstUpdatePage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.FirstUpdatePageViewModel();
        }
    }
}