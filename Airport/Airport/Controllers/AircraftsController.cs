using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class AircraftsController : Controller
    {
        private AircraftService Services { get; }

        public AircraftsController(AircraftService services) => Services = services;

        // GET api/Aircrafts
        [HttpGet]
        public List<Aircraft> GetAircrafts() => Services.GetAircraft();

        // GET api/Aircrafts/5
        [HttpGet("{id}")]
        public ObjectResult GetAircraftDetails(int id)
        {
            if (Services.IsAircraft(id) == null) return NotFound("Aircraft with id = " + id + "not found");
            return Ok(Services.GetAircraftDetails(id));
        }

        // POST api/Aircrafts
        [HttpPost]
        public ObjectResult PostAircraft([FromBody]Aircraft aircraft)
        {
            Services.AddAircraft(aircraft);
            return Ok(aircraft);
        }

        // PUT api/Aircrafts/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutAircraft(int id, [FromBody]Aircraft aircraft)
        {
            if (Services.IsAircraft(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.UpdateAircraft(aircraft);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Aircrafts/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteAircraft(int id)
        {
            if (Services.IsAircraft(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.RemoveAircraft(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
        
        // DELETE api/Aircrafts
        [HttpDelete]
        public HttpResponseMessage DeleteAircrafts()
        {
            Services.RemoveAircrafts();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
