﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkInMobileFinal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkInMobileFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametrePage : ContentPage
    {
        public ParametrePage()
        {
            InitializeComponent();
            BindingContext = new ParametrePageViewModel();
        }
    }
}