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
    public partial class SchoolView : ContentView
    {
        private static SchoolView _instance;
        public static SchoolView Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SchoolView();
                return _instance;
            }
        }
        public SchoolView()
        {
            InitializeComponent();
        }
    }
}