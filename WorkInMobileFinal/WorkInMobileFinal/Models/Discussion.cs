using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkInMobileFinal.Models
{
    public class Discussion
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("demandeur")]
        public DemandeurIdentite DemandeurIdentite { get; set; }
        [JsonProperty("employeur")]
        public EmployeurIdentite EmployeurIdentite { get; set; }
        [JsonProperty("messages")]
        public IEnumerable<Message> Messages { get; set; }
    }
}
