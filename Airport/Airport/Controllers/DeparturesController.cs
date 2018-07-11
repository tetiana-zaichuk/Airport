using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class DeparturesController : Controller
    {
        private DepartureService Services { get; }

        public DeparturesController(DepartureService services) => Services = services;

        // GET api/Departures
        [HttpGet]
        public List<Departure> GetDepartures() => Services.GetDeparture();

        // GET api/Departures/5
        [HttpGet("{id}")]
        public ObjectResult GetDepartureDetails(int id)
        {
            if (Services.IsDeparture(id) == null) return NotFound("Departure with id = " + id + "not found");
            return Ok(Services.GetDepartureDetails(id));
        }

        // POST api/Departures
        [HttpPost]
        public ObjectResult PostDeparture([FromBody]Departure departure)
        {
            Services.AddDeparture(departure);
            return Ok(departure);
        }

        // PUT api/Departures/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutDeparture(int id, [FromBody]Departure departure)
        {
            if (Services.IsDeparture(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.UpdateDeparture(departure);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Departures/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteDeparture(int id)
        {
            if (Services.IsDeparture(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.RemoveDeparture(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Departures
        [HttpDelete]
        public HttpResponseMessage DeleteDepartures()
        {
            Services.RemoveDepartures();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
