using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class AircraftsController : Controller
    {
        private IService<Aircraft> Services { get; }

        public AircraftsController(IService<Aircraft> services) => Services = services;

        // GET api/Aircrafts
        [HttpGet]
        public List<Aircraft> GetAircrafts() => Services.GetAll();

        // GET api/Aircrafts/5
        [HttpGet("{id}")]
        public ObjectResult GetAircraftDetails(int id)
        {
            if (Services.IsExist(id) == null) return NotFound("Aircraft with id = " + id + " not found");
            return Ok(Services.GetDetails(id));
        }

        // POST api/Aircrafts
        [HttpPost]
        public ObjectResult PostAircraft([FromBody]Aircraft aircraft)
        {
            Services.Add(aircraft);
            return Ok(aircraft);
        }

        // PUT api/Aircrafts/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutAircraft(int id, [FromBody]Aircraft aircraft)
        {
            if(Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Update(aircraft);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Aircrafts/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteAircraft(int id)
        {
            if (Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        
        // DELETE api/Aircrafts
        [HttpDelete]
        public HttpResponseMessage DeleteAircrafts()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
