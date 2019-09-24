using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkInMobileFinal.Models
{
    public class CommentairesSend
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("commentaire")]
        public Commentaire Commentaire { get; set; }
        [JsonProperty("employeur")]
        public EmployeurIdentite EmployeurIdentite { get; set; }
    }
}
