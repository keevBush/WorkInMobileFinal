using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkInMobileFinal.CustomEffects
{
    public class CustomFadeOut
    {
        public static async Task FadeTo(params View[] views)
        {
            views[0].IsVisible = true;
            await views[0].FadeTo(1,150);
            for(int i = 1; i < views.Length; i++)
            {
                await views[i].FadeTo(0,150);
                views[i].IsVisible = false;
            }
        }
    }
}
