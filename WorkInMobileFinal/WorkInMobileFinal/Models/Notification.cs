using LiteDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkInMobileFinal.Models
{
    public class Notification
    {
        [JsonProperty("id")]
        [BsonId]
        [BsonField("id")]
        public string Id { get; set; }
        [JsonProperty("msg")]
        [BsonField("msg")]
        public string Msg { get; set; }
        [JsonProperty("customData")]
        [BsonField("customData")]
        public CustomDataNotifications CustomData { get; set; }
        [JsonProperty("date")]
        [BsonField("date")]
        public DateTime Date { get; set; }
    }
}
