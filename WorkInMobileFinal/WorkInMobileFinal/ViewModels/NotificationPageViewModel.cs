using Microsoft.AppCenter.Push;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkInMobileFinal.Models;
using WorkInMobileFinal.Views;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class NotificationPageViewModel:BaseViewModel
    {
        private int _page;
        private INavigation navigation;

        public Command NotificationClickCommand { get; set; }
        public ObservableCollection<Notification> Notifications { get; set; }
        public NotificationPageViewModel()
        {
            NotificationClickCommand = new Command(ExecuteNotificationClickCommand);
            this.Notifications = new ObservableCollection<Notification>();
            _page = 1;
            StorageHelpers.LiteDbHelper.Notifications.ToList().ForEach(n => Notifications.Add(n));
            LoadData(_page);
            MessagingCenter.Subscribe<App, PushNotificationReceivedEventArgs>(this, "notification", ReceiveData);
        }

        public NotificationPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
            NotificationClickCommand = new Command(ExecuteNotificationClickCommand);
            this.Notifications = new ObservableCollection<Notification>();
            _page = 1;
            StorageHelpers.LiteDbHelper.Notifications.ToList().ForEach(n => Notifications.Add(n));
            LoadData(_page);
            MessagingCenter.Subscribe<App, PushNotificationReceivedEventArgs>(this, "notification", ReceiveData);
        }

        private async void ExecuteNotificationClickCommand(object obj)
        {

            var data = (CustomDataNotifications)obj;
            if(data.PageType == PageType.Publication)
            {
                await navigation.PushAsync(new PublicationDetailPage(data));
            }
        }

        public void ReceiveData(object s, PushNotificationReceivedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var custom = CustomDataNotifications.ConvertCustomData(e.CustomData);
                var n = new Notification
                {
                    Id = custom.Id,
                    Msg = e.Message,
                    CustomData = new CustomDataNotifications
                    {
                        PageType = custom.PageType,
                        IdData = custom.IdData
                    },
                    Date = custom.Date
                };
                Notifications.Add(n);
                StorageHelpers.LiteDbHelper.NewNotification(n);
            });
        }

        public async void LoadData(int page)
        {
            try
            {
                var notifications = await RestService.For<Services.IBackendService>(Configurations.ServerConfig.Host).GetNotifications(StorageHelpers.LiteDbHelper.CurrentUser.Id);
                if (StorageHelpers.LiteDbHelper.Notifications == null || StorageHelpers.LiteDbHelper.Notifications.Count() < notifications.Count() )
                {
                    var excepts = notifications.Except(StorageHelpers.LiteDbHelper.Notifications);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        notifications.ToList().ForEach(n => Notifications.Add(n));
                    });
                }
            }
            catch (Exception e)
            {
                await MaterialDialog.Instance.SnackbarAsync($"Erreur: {e.Message}","OK",3000,Configurations.MaterialConfig.MaterialSnackbarConfigurationError); 
            }
        }
    }
}
