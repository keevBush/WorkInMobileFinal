﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Iid;

namespace WorkInMobileFinal.Droid
{
    //[Service]
    //[IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService 
        //:FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";

        public  void OnTokenRefresh()
        {
            //Log.Debug(TAG, "Je suis le service ");
            //try
            //{

            //    var refreshedToken = FirebaseInstanceId.Instance.Token;
            //    Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            //    SendRegistrationToServer(refreshedToken);
            //}
            //catch (Exception e)
            //{

            //    Log.Debug("error ex: ", e.Message);

            //}

        }

        void SendRegistrationToServer(string token)
        {
            // Add custom implementation, as needed.
        }
    }
}