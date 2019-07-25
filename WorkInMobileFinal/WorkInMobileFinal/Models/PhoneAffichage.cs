using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkInMobileFinal.Models
{
    public class PhoneAffichage
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("dial_code")]
        public string DialCode { get; set; }
        [JsonProperty("name")]
        public string CountryName { get; set; }
        public override string ToString()
        {
            return DialCode+", "+Code;
        }
    }
}
