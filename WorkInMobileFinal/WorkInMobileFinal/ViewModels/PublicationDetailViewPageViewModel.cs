using System;
using System.Collections.Generic;
using System.Text;
using WorkInMobileFinal.Models;

namespace WorkInMobileFinal.ViewModels
{
    public class PublicationDetailViewPageViewModel : BaseViewModel
    {
        private Publication _publication;
        public Publication Publication
        {
            get => _publication;
            set
            {
                Publication = value;
                OnPropertyChanged("Publication");
            }
        }
        public PublicationDetailViewPageViewModel(Publication publication)
        {
            this.Publication = publication;
        }
    }
}
