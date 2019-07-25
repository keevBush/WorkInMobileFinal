using LiteDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WorkInMobileFinal.Models
{
    public class DemandeurIdentite 
    {
        [BsonId]
        [BsonField("id")]
        [JsonProperty("id")]
        public string Id { get; set; }
        [BsonField("nom")]
        [JsonProperty("nom")]
        public string Nom { get; set; }
        [BsonField("postnom")]
        [JsonProperty("postnom")]
        public string Postnom { get; set; }
        [BsonField("prenom")]
        [JsonProperty("prenom")]
        public string Prenom { get; set; }
        [BsonField("email")]
        [JsonProperty("email")]
        public string Email { get; set; }
        [BsonField("motDePasse")]
        [JsonProperty("motDePasse")]
        public string Password { get; set; }
        [BsonField("username")]
        [JsonProperty("username")]
        public string Username { get; set; }
        [BsonField("adresse")]
        [JsonProperty("adresse")]
        public string Adresse { get; set; }
        [BsonField("telephone")]
        [JsonProperty("telephone")]
        public string Telephone { get; set; }
        [JsonProperty("nationalite")]
        public string Nationalite { get; set; }
        [BsonField("genre")]
        [JsonProperty("genre")]
        public Genre Genre { get; set; }
        [BsonField("naissance")]
        [JsonProperty("naissance")]
        public DateTime Naissance { get; set; }
        [BsonField("langues")]
        [JsonProperty("langues")]
        public IEnumerable<string> LanguesParle { get; set; }
        [BsonField("aPropos")]
        [JsonProperty("aPropos")]
        public string Apropos { get; set; }
        [BsonField("localisation")]
        [JsonProperty("localisation")]
        public string Localisation { get; set; }
        [BsonField("isVerified")]
        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }
    }
    public enum Genre
    {
        Homme, Femme
    }
}