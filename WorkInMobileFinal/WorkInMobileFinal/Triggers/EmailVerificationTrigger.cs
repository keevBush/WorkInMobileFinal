using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF.Material.Forms.UI;

namespace WorkInMobileFinal.Triggers
{
    public class EmailVerificationTrigger : TriggerAction<MaterialTextField>
    {
        protected override void Invoke(MaterialTextField sender)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(sender.Text);
                sender.HasError = false;
            }
            catch
            {
                sender.HasError = true;
                sender.ErrorColor = Color.Red;
                sender.ErrorText = "La valeur saisie n'est pas une adrresse email valide";
            }
        }
    }
}
