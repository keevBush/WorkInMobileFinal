using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkInMobileFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfosUserView : ContentView
    {
        private static InfosUserView _instance;
        public static InfosUserView Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InfosUserView();
                return _instance;
            }
        }
        public InfosUserView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.InfoUserViewViewModel();
        }
    }
}