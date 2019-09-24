using System;
using System.Collections.Generic;
using System.Text;

namespace WorkInMobileFinal.Models
{
    public class CustomDataNotifications
    {
        public PageType PageType { get; set; }
        public string Id { get; set; }
        public string IdData { get; set; }
        public DateTime Date { get; set; }

        public static CustomDataNotifications ConvertCustomData (IDictionary<string,string> keyValues)
        {
            var customData = new CustomDataNotifications
            {
                Date = DateTime.Parse(keyValues["date"]),
                Id = keyValues["id"],
                PageType = (PageType)(Enum.Parse(typeof(PageType),keyValues["pagetype"])),
                IdData = keyValues["idData"]
            };
            return customData;
        }

    }
    public enum PageType
    {
        Offre=0,Message=1,Publication=2
    }
}
