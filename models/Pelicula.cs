using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace docker_mongo_webapi.models
{
    public class Pelicula
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("Name")]
        [BsonElement("Name")]
        [Display(Name="NombrePelicula")]
        public string Name { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int NumeroPersonajes { get; set; }
    }
}