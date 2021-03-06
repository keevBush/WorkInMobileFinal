﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs.Configurations;

namespace WorkInMobileFinal.Configurations
{
    public class MaterialConfig
    {
        private static MaterialAlertDialogConfiguration _materialAlertDialogConfiguration;
        public static MaterialAlertDialogConfiguration MaterialAlertDialogConfiguration
        {
            get
            {
                if(_materialAlertDialogConfiguration == null)
                {
                    _materialAlertDialogConfiguration = new MaterialAlertDialogConfiguration
                    {
                        BackgroundColor = Color.RoyalBlue,
                        MessageTextColor = Color.White,
                        TintColor = Color.White,
                        CornerRadius = 15
                    };
                }
                return _materialAlertDialogConfiguration;
            }
        }


        private static MaterialLoadingDialogConfiguration _materialLoadingDialogConfiguration;
        public static MaterialLoadingDialogConfiguration MaterialLoadingDialogConfiguration
        {
            get
            {
                if(_materialLoadingDialogConfiguration == null)
                {
                    _materialLoadingDialogConfiguration = new MaterialLoadingDialogConfiguration
                    {
                        BackgroundColor = Color.RoyalBlue,
                        MessageTextColor = Color.White,
                        TintColor = Color.White,
                        CornerRadius = 15
                    };
                    
                }
                return _materialLoadingDialogConfiguration;
            }
        }


        private static MaterialSnackbarConfiguration _materialSnackbarConfiguration;
        
        public static MaterialSnackbarConfiguration MaterialSnackbarConfiguration
        {
            get
            {
                if(_materialSnackbarConfiguration == null)
                {
                    _materialSnackbarConfiguration = new MaterialSnackbarConfiguration
                    {
                        BackgroundColor = Color.RoyalBlue,
                        MessageTextColor = Color.White,
                        TintColor = Color.White,
                        CornerRadius = 15
                    };
                }
                return _materialSnackbarConfiguration;
            }

        }
        private static MaterialSnackbarConfiguration _materialSnackbarConfigurationError;

        public static MaterialSnackbarConfiguration MaterialSnackbarConfigurationError
        {
            get
            {
                if (_materialSnackbarConfiguration == null)
                {
                    _materialSnackbarConfiguration = new MaterialSnackbarConfiguration
                    {
                        BackgroundColor = Color.Red,
                        MessageTextColor = Color.White,
                        TintColor = Color.White,
                        CornerRadius = 15
                    };
                }
                return _materialSnackbarConfiguration;
            }

        }
    }
}
