using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private FlightService Services { get; }

        public FlightsController(FlightService services) => Services = services;

        // GET api/Flights
        [HttpGet]
        public List<Flight> GetFlights() => Services.GetFlight();

        // GET api/Flights/5
        [HttpGet("{id}")]
        public ObjectResult GetFlightDetails(int id)
        {
            if (Services.IsFlight(id) == null) return NotFound("Flight with id = " + id + "not found");
            return Ok(Services.GetFlightDetails(id));
        }

        // POST api/Flights
        [HttpPost]
        public ObjectResult PostFlight([FromBody]Flight flight)
        {
            Services.AddFlight(flight);
            return Ok(flight);
        }

        // PUT api/Flights/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutFlight(int id, [FromBody]Flight flight)
        {
            if (Services.IsFlight(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.UpdateFlight(flight);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Flights/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteFlight(int id)
        {
            if (Services.IsFlight(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.RemoveFlight(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Flights
        [HttpDelete]
        public HttpResponseMessage DeleteFlights()
        {
            Services.RemoveFlights();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
