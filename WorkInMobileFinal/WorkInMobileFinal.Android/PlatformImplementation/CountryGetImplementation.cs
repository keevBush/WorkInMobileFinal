using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WorkInMobileFinal.Droid.PlatformImplementation;
using WorkInMobileFinal.Services;
[assembly: Xamarin.Forms.Dependency(typeof(CountryGetImplementation))]
namespace WorkInMobileFinal.Droid.PlatformImplementation
{
    public class CountryGetImplementation:IAssetManager
    {

        public string AssetContent {
            get {
                string content;
                AssetManager assets = Application.Context.Assets;
                using (StreamReader sr = new StreamReader(assets.Open("phones.json")))
                {
                    content = sr.ReadToEnd();
                }
                return content;
            }
        }
    }
}