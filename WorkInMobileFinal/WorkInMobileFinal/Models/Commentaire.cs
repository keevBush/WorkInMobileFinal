using Newtonsoft.Json;
using System;

namespace WorkInMobileFinal.Models
{
    public class Commentaire
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("sentiment")]
        public bool Sentiment { get; set; }
    }
}