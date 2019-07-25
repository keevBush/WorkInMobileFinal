using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XF.Material.Forms.UI;

namespace WorkInMobileFinal.Triggers
{
    public class UsernameVerificationTrigger : TriggerAction<MaterialTextField>
    {
        protected override void Invoke(MaterialTextField sender)
        {
            var space = sender.Text.Where(c => c == ' ').ToList();
            if(space.Count!=0)
            {
                sender.HasError = true;
                sender.ErrorColor = Color.Red;
                sender.ErrorText = "La valeur saisie ne doit pas contenir d'espace";
            }
            else
            {
                sender.HasError = false ;
            }
        }
    }
}
