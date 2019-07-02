using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace WorkInMobileFinal.ViewModels
{
    public class FirstUpdatePageViewModel:BaseViewModel
    {
        public ObservableCollection<string> CountryList{ get; set; }
        public FirstUpdatePageViewModel()
        {
            this.CountryList = new ObservableCollection<string>(GetListOfCountry());
        }

        private IEnumerable<string> GetListOfCountry()
        {
            var data = DependencyService.Get<Services.IAssetManager>().AssetContent;


            var jsonContent = JsonConvert.DeserializeObject<IEnumerable <Dictionary<string,string>>>(data);

            var values = jsonContent.Select(c=>c["name"]).ToList();
            return values;
        }
    }
}
