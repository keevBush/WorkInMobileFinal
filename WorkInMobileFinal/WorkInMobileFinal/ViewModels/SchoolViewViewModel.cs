using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WorkInMobileFinal.Models;

namespace WorkInMobileFinal.ViewModels
{
    public class SchoolViewViewModel:BaseViewModel
    {
        public ObservableCollection<string> Competences { get; set; }
        public ObservableCollection<ExperienceProffessionnelle> ExperienceProffessionnelles { get; set; }
        public SchoolViewViewModel()
        {
            this.Competences = new ObservableCollection<string>
            {
                "PHP","Angular","ASP"
            };
            ExperienceProffessionnelles = new ObservableCollection<ExperienceProffessionnelle>();
        } 
    }
}
