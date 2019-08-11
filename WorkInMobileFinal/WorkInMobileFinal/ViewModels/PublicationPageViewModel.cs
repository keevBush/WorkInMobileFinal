using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using WorkInMobileFinal.Models;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace WorkInMobileFinal.ViewModels
{
    public class PublicationPageViewModel:BaseViewModel
    {
        public PublicationDetails PublicationDetails { get; set; }
        public ObservableCollection<string> Lst { get; set; } 
        public ObservableCollection<string> TypePublication { get; set; }
        public Command AddTagCommand { get; set; }
        public Command DeleteChipCommand { get; set; }
        public Command SaveCommand { get; set; }
        public Command DeleteTagCommad { get; set; }
        public Command SelectPubTypeCommand { get; set; }
        public Command FileChoiceCommand { get; set; }
        public string CurrentTag { get; set; }
        private string _typePub;
        FileInfo f;
        private Stream _imgSource;
        public Stream ImgSource
        {
            get => _imgSource;
            set
            {
                _imgSource = value;
                OnPropertyChanged("ImgSource");
            }
        }
        public string TypePub
        {
            get =>_typePub;
            set
            {
                _typePub = value;
                OnPropertyChanged("TypePub");
            }
        }
        public bool _isVisible = false;
        public bool IsVisible
        {
            get =>_isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged("IsVisible"); 
            }
        }
        public PublicationPageViewModel()
        {
            PublicationDetails = new PublicationDetails();
            Lst= new ObservableCollection<string>() ;
            TypePublication = new ObservableCollection<string>(Enum.GetNames(typeof(TypePublication)));
            DeleteTagCommad = new Command(ExecuteDeleteTagCommand);
            AddTagCommand = new Command(ExecuteAddTagCommand);
            SaveCommand = new Command(ExecuteSaveCommand);
            FileChoiceCommand = new Command(ExecuteFileChoiceCommandAsync);
            SelectPubTypeCommand = new Command(ExecuteSelectPubTypeCommand);
        }

        private void ExecuteDeleteTagCommand(object obj)
        {
            var data = obj;
        }

        private async void ExecuteSaveCommand(object obj)
        {
            PublicationDetails.Id = Guid.NewGuid().ToString();
            PublicationDetails.Tags = Lst;
            PublicationDetails.TypePublication = (Models.TypePublication)Enum.Parse(typeof(Models.TypePublication), TypePub);
            var api = RestService.For<Services.IBackendService>(Configurations.ServerConfig.Host);
            try
            {
                if (PublicationDetails.TypePublication != Models.TypePublication.Text)
                {
                    var pub = PublicationDetails.TypePublication;
                    var link = await api.UploadFile(TypePub.ToLower(), new StreamPart(f.Open(FileMode.Open), f.Name, $"{TypePub.ToLowerInvariant()}/{f.Extension}"));
                    var l = link;
                    PublicationDetails.Value = l;
                }
                else
                    PublicationDetails.Value = null;
                
            }
            catch (Exception e)
            {
                if (e is NullReferenceException)
                    await MaterialDialog.Instance.SnackbarAsync("Erreur:Aucun fichier selectionné", 3000, Configurations.MaterialConfig.MaterialSnackbarConfigurationError);
            }
           
        }

        private void ExecuteSelectPubTypeCommand(object obj)
        {

            if (TypePub == "Image")
                IsVisible = true;
            else if (TypePub == "Text")
                IsVisible = false;
            else if (TypePub == "Video")
                IsVisible = true;
        }

        private async void ExecuteFileChoiceCommandAsync(object obj)
        {

            if (TypePub == "Image")
            {
                var file = await CrossFilePicker.Current.PickFile(new string[] { "image/*" });
                f = new FileInfo(file.FilePath);
                if (f.Length / 1024 / 1024 <= 20)
                    ImgSource = f.Open(FileMode.Open);
                else
                    throw new Exception("La taille de votre fichier est trop grande");
            }
            else if (TypePub == "Video")
            {
                var file = await CrossFilePicker.Current.PickFile(new string[] { "video/*" });
                f = new FileInfo(file.FilePath);
            }

        }

        private void ExecuteAddTagCommand(object obj)
        {
            if (!Lst.Contains(CurrentTag))
                Lst.Add(CurrentTag);
            else
                MaterialDialog.Instance.LoadingSnackbarAsync("Ce tag existe déjà",Configurations.MaterialConfig.MaterialSnackbarConfiguration);
        }
    }
}
