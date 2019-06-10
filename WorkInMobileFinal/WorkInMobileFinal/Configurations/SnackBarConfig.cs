using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace WorkInMobileFinal.Configurations
{
    public class SnackBarConfig
    {
        private static MaterialSnackbarConfiguration _materialSnackbarConfiguration;
        
        public static MaterialSnackbarConfiguration MaterialSnackbarConfiguration
        {
            get
            {
                if(_materialSnackbarConfiguration == null)
                {
                    _materialSnackbarConfiguration = new MaterialSnackbarConfiguration
                    {
                        BackgroundColor = Color.FromHex("#020b24"),
                        MessageTextColor = Color.FromHex("#d0d7e9"),
                        TintColor = Color.FromHex("#8a2be2")
                    };
                }
                return _materialSnackbarConfiguration;
            }

        }
    }
}
