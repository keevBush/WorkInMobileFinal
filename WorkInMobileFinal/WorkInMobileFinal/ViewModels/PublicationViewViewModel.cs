using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WorkInMobileFinal.Models;
using Xamarin.Forms;

namespace WorkInMobileFinal.ViewModels
{
    public class PublicationViewViewModel:BaseViewModel
    {

        public Command SelectCommand { get; set; }
        private bool _isLoading;
        public bool IsLoading {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }
        private INavigation Navigation { get; set; }
        public ObservableCollection<Publication> Publications { get; set; }
        public PublicationViewViewModel(INavigation navigation)
        {
            Navigation = navigation;
            SelectCommand = new Command(ExecuteSelectCommand);
            Publications = new ObservableCollection<Publication>();
            LoadData();
        }

        private void ExecuteSelectCommand(object obj)
        {
            MessagingCenter.Send(this, "pub", (Publication)obj);            
        }

        public async void LoadData()
        {
            IsLoading = true;
            await Task.Delay(3000);
            
            for (int i = 0; i < 5; i++)
            {
                var publication = new Publication {
                    Id = i.ToString(),
                    PublicationDetails = new PublicationDetails
                    {
                        Id = i.ToString(),
                        Date = new DateTime(1, i+1, 1),
                        Legende = $"Legende {i}",
                        Tags = new List<string> { $"Tag_1_{i}", $"Tag_2_{i}", $"Tag_3_{i}" },
                        TypePublication = TypePublication.Text,
                        Value = "Un jolie petit text"
                    },
                    Commentaires = new List<Commentaire>
                    {
                        new Commentaire
                        {
                            Value =$"Value_1_{i}"
                        },
                        new Commentaire
                        {
                            Value =$"Value_2_{i}"
                        },
                        new Commentaire
                        {
                            Value =$"Value_5_{i}"
                        }
                    },
                    Likes = new List<Like> {
                        new Like
                        {
                            Id= Guid.NewGuid().ToString(),
                            Etat = true
                        }
                    }
                };
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsLoading = false;
                    Publications.Add(publication);
                });
            }
        }
    }
}
