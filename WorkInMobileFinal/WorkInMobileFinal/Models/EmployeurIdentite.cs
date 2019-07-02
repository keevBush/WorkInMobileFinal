﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace WorkInMobileFinal.Models
{
    public class EmployeurIdentite
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nom")]
        public string Nom { get; set; }
        [JsonProperty("adresse")]
        public string Adresse { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("profil")]
        public string ImageProfil { get; set; }
        [JsonProperty("idNational")]
        public string IdNational { get; set; }
        [JsonProperty("domaines")]
        public IEnumerable<string> Domaines { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("motDePasse")]
        public string MotDePasse { get; set; }
    }
}