using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace WorkInMobileFinal.StorageHelpers
{
    public class SecureStorageHelper
    {
        public static string AuthKey
        {
            get
            {
                try
                {
                    return  SecureStorage.GetAsync("auth_key").Result; 
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            set
            {
                try
                {
                    SecureStorage.SetAsync("auth_key", value);
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }
        public static void DeleteKey()
        {
            SecureStorage.RemoveAll();
        }
    }
}
