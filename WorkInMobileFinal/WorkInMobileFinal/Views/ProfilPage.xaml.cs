using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkInMobileFinal.Models;
using WorkInMobileFinal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkInMobileFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPage : ContentPage
    {
        public ProfilPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<PublicationViewViewModel, Publication>(this, "pub", (s, publication) =>
               {
                   Device.BeginInvokeOnMainThread(() =>
                   {
                       if (publication.PublicationDetails.TypePublication == TypePublication.Image)
                           Navigation.PushAsync(new Views.PublicationDetailPage(publication));
                       else if (publication.PublicationDetails.TypePublication == TypePublication.Text)
                           Navigation.PushModalAsync(new NavigationPage(new Views.PublicationViewDetailTexte(publication)));
                   });
                  
               });
        }

        private void BtnInfoTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void BtnPublicationsTapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void BtnSchoolTapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }

        private async void BtnInfo_Clicked(object sender, EventArgs e)
        {
            await CustomEffects.CustomFadeOut.FadeTo(bottomInfo, bottomPublication, bottomSchool);
            if(!(content.Children[0] is Views.InfosUserView))
            {
                content.Children.Clear();
                content.Children.Add(InfosUserView.Instance);
            }
        }

        private async void BtnPublications_Clicked(object sender, EventArgs e)
        {
            await CustomEffects.CustomFadeOut.FadeTo(bottomPublication, bottomInfo, bottomSchool);
            if (!(content.Children[0] is Views.PublicationView))
            {
                content.Children.Clear();
                content.Children.Add(PublicationView.Instance);
            }
        }

        private async void BtnSchool_Clicked(object sender, EventArgs e)
        {
            await CustomEffects.CustomFadeOut.FadeTo(bottomSchool, bottomPublication, bottomInfo);
            if (!(content.Children[0] is Views.SchoolView))
            {
                content.Children.Clear();
                content.Children.Add(SchoolView.Instance);
            }

        }
    }
}