using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WorkInMobileFinal.CustomControls;
using WorkInMobileFinal.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomEditor),typeof(CustomEditorRenderer))]
namespace WorkInMobileFinal.Droid.CustomRenderers
{
    public class CustomEditorRenderer:EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {

        }
        public CustomEditorRenderer() : base(Android.App.Application.Context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
        }
    }
}