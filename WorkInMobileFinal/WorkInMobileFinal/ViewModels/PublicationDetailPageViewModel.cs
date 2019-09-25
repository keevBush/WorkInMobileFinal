using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using WorkInMobileFinal.Models;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class PublicationDetailPageViewModel:BaseViewModel
    {
        private bool _isRefresh;
        public bool IsRefresh
        {
            get => _isRefresh;
            set
            {
                _isRefresh = value;
                OnPropertyChanged("IsRefresh");
            }
        }
        private Publication _publication;
        public Publication Publication
        {
            get => _publication;
            set
            {
                _publication = value;
                OnPropertyChanged("Publication");
            }
        }
        private CustomDataNotifications data;

        public PublicationDetailPageViewModel(CustomDataNotifications data)
        {
            this.data = data;
            LoadData();
        }
        public PublicationDetailPageViewModel(Publication publication)
        {
            this.Publication = publication;
        }
        public async void LoadData()
        {
            try
            {
                IsRefresh = true;
                var publication = await RestService.For<Services.IBackendService>(Configurations.ServerConfig.Host)
                                .GetPublication(data.IdData);
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.Publication = publication;
                    this.IsRefresh = false;
                });
                
            }
            catch (Exception e)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.IsRefresh = false;
                });
                await MaterialDialog.Instance.SnackbarAsync($"{e.Message}"); 
            }
            
        }
        
    }
}
