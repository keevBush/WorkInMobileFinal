using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkInMobileFinal.Models;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class ActivitePageViewModel:BaseViewModel
    {
        private int page = 0;
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
        public ObservableCollection<Proposition> Propositions { get; set; }
        public Command RefreshCommand { get; set; }
        public Command ParticiperCommand { get; set; }
        public ActivitePageViewModel()
        {
            this.Propositions = new ObservableCollection<Proposition>();
            this.RefreshCommand = new Command(ExecuteRefreshCommand);
            this.ParticiperCommand = new Command(ExecuteParticiperCommand);
            LoadData(page);
        }

        private void ExecuteRefreshCommand(object obj)
        {
          
            page = 0;
            Device.BeginInvokeOnMainThread(() =>
            {
                this.Propositions.Clear();
            });
            LoadData(page);
        }

        public async void LoadData(int page)
        {
            try
            {
                IsRefresh = true;
                page++;
                var lst = await RestService.For<Services.IBackendService>(Configurations.ServerConfig.Host).GetPropositions(page);
                Device.BeginInvokeOnMainThread(() =>
                {
                    lst.ToList().ForEach(p => Propositions.Add(p));
                    IsRefresh = false;
                });
            }
            catch(Exception e)
            {
                await MaterialDialog.Instance.SnackbarAsync($"Erreur: {e.Message}", "OK", 6000, Configurations.MaterialConfig.MaterialSnackbarConfigurationError);
            }

        }

        private async void ExecuteParticiperCommand(object obj)
        {
            await MaterialDialog.Instance.SnackbarAsync("En contact du serveur ...", "OK",3000,Configurations.MaterialConfig.MaterialSnackbarConfiguration);
        }
    }
}
