using Newtonsoft.Json;
using System;

namespace WorkInMobileFinal.Models
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("msg")]
        public string Msg { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("isRead")]
        public bool IsRead { get; set; }
        [JsonProperty("envoyeur")]
        public object Envoyeur { get; set; }
    }
}