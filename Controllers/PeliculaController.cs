using docker_mongo_webapi.models;
using docker_mongo_webapi.services;
using Microsoft.AspNetCore.Mvc;

namespace docker_mongo_webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculaController : ControllerBase
    {
        private readonly PeliculaServices _service;
        public PeliculaController(PeliculaServices service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Pelicula>> Get() =>
            _service.GetAll();

        [HttpGet("{id:length(24)}", Name="GetPelicula")]
        public ActionResult<Pelicula> Get(string id)
        {
            var pelicula = _service.GetById(id);
            if(pelicula == null) return BadRequest("book is null");

            return pelicula;
        } 
        [HttpPost]
        public ActionResult<Pelicula> Post(Pelicula pelicula)
        {
            _service.Create(pelicula);

            return CreatedAtAction(nameof(Get), new {id = pelicula.Id.ToString()},pelicula );
        }
        [HttpPut("{id:length(24)}")]
        public ActionResult Put(string id, Pelicula peliculaIn)
        {
            var pelicula = _service.GetById(id);

            if(pelicula == null)return BadRequest("Pelicula is null");

            _service.Uptate(id, peliculaIn);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            var pelicula = _service.GetById(id);

            if(pelicula == null) return BadRequest("pelicula is null");

            _service.Remove(pelicula);

            return NoContent();
        }
    }
}