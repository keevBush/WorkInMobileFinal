using System;
using System.Collections.Generic;
using System.Text;
using WorkInMobileFinal.Models;
using WorkInMobileFinal.StorageHelpers;

namespace WorkInMobileFinal.ViewModels
{
    public class HomePageViewModel:BaseViewModel
    {
        public DemandeurIdentite CurrentUser { get; set; } = LiteDbHelper.CurrentUser; 
        public HomePageViewModel()
        {

        }
    }
}
