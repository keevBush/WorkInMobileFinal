using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkInMobileFinal.Models
{
    public class Proposition
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("offre")]
        public Offre Offre { get; set; }
        [JsonProperty("demandeursInteressees")]
        public IEnumerable<DemandeurIdentite> DemandeurIdentites { get; set; }
        public override string ToString()
        {
            return "ok";
        }
    }
}
