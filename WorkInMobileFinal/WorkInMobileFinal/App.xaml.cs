using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkInMobileFinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            MainPage = new NavigationPage (new Views.PublicationPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            if (StorageHelpers.SecureStorageHelper.AuthKey != null)
                AppCenter.SetUserId(StorageHelpers.SecureStorageHelper.AuthKey);
            AppCenter.Start("android=41b3b948-ee1e-452e-ae03-ea48653a1d60", typeof(Push));
            Push.PushNotificationReceived += Push_PushNotificationReceived;
        }

        private void Push_PushNotificationReceived(object sender, PushNotificationReceivedEventArgs e)
        {
            var data = e;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}