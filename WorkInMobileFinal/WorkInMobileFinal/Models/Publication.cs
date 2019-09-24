using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkInMobileFinal.Models
{
    public class Publication
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("details")]
        public PublicationDetails PublicationDetails { get; set; }
        [JsonProperty("commentaires")]
        public IEnumerable<Commentaire> Commentaires { get; set; }
        [JsonProperty("likes")]
        public IEnumerable<Like> Likes { get; set; }
        [JsonProperty("demandeur")]
        public DemandeurIdentite Demandeur { get; set; }
        //Not Serializable member
        [JsonIgnore]
        public int CommentairesNb { get; set; }
        [JsonIgnore]
        public int LikeNb { get; set; }
    }
}
