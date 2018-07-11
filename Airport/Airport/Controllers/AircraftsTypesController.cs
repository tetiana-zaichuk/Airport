using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AircraftsTypes : Controller
    {
        private AircraftTypeService Services { get; }

        public AircraftsTypes(AircraftTypeService services) => Services = services;

        // GET api/AircraftsTypes
        [HttpGet]
        public List<AircraftType> GetAircraftsTypes() => Services.GetAircraftsTypes();

        // GET api/AircraftsTypes/5
        [HttpGet("{id}")]
        public ObjectResult GetAircraftTypeDetails(int id)
        {
            return Ok(Services.GetAircraftTypeDetails(id));
        }

        // POST api/AircraftsTypes
        [HttpPost]
        public ObjectResult PostAircraftType([FromBody]AircraftType aircraftType)
        {
            Services.AddAircraftType(aircraftType);
            return Ok(aircraftType);
        }

        // PUT api/AircraftsTypes/5
        [HttpPut("{id}")]
        public ObjectResult PutAircraftType(int id, [FromBody]AircraftType aircraftType)
        {
            if ( Services.IsAircraftTypes(id)== null) return BadRequest("AircraftType with id = " + id + "not found");
            Services.UpdateAircraftType(aircraftType);
            return Ok(aircraftType);
        }

        // DELETE api/AircraftsTypes/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteAircraftType(int id)
        {
            if (Services.IsAircraftTypes(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.RemoveAircraftType(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/AircraftsTypes
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteAircraftsTypes()
        {
            Services.RemoveAircraftsTypes();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
