using System;
using System.Collections.Generic;
using System.Text;
using WorkInMobileFinal.Models;

namespace WorkInMobileFinal.ViewModels
{
    public class InfoUserViewViewModel:BaseViewModel
    {
        public DemandeurIdentite DemandeurIdentite { get; set; } = StorageHelpers.LiteDbHelper.CurrentUser;
        public InfoUserViewViewModel()
        {

        }
    }
}
