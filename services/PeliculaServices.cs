using docker_mongo_webapi.databaseSetting;
using docker_mongo_webapi.models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace docker_mongo_webapi.services
{
    public class PeliculaServices
    {
        private readonly IMongoCollection<Pelicula> _pelicula;
        private readonly IConfiguration _config;
        public PeliculaServices(IOptions<MongoDbSettings> mongoDbSettings, IConfiguration config)
        {
            _config = config;
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _pelicula = database.GetCollection<Pelicula>(mongoDbSettings.Value.CollectionName);
        }

        public List<Pelicula> GetAll() => 
            _pelicula.Find(Pelicula => true).ToList();

        public Pelicula GetById(string id) => 
            _pelicula.Find<Pelicula>(pelicula => pelicula.Id == id).FirstOrDefault();

        public Pelicula Create(Pelicula pelicula)
        {
            _pelicula.InsertOne(pelicula);
            return pelicula;
        }
        public void Uptate(string id, Pelicula peliculaIn) => 
            _pelicula.ReplaceOne(pelicula => pelicula.Id == id, peliculaIn);

        public void Remove(string id) => 
            _pelicula.DeleteOne(pelicula => pelicula.Id == id);

        public void Remove(Pelicula peliculaIn) => 
            _pelicula.DeleteOne(pelicula => pelicula.Id == peliculaIn.Id);
    }
}