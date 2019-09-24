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
    public partial class PublicationView : ContentView
    {
        private static PublicationView _instance;
        public static PublicationView Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PublicationView();
                return _instance;
            }
        }
        public PublicationView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.PublicationViewViewModel();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (View)(e.CurrentSelection);
            if (item.IsVisible)
            {
                await item.FadeTo(0, 550, Easing.SinOut);
                item.IsVisible = false;
            }
            else
            {
                item.IsVisible = true;
                await item.FadeTo(0.7, 550, Easing.SinIn);
            }
        }
    }
}