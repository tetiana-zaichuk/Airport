using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class PilotsController : Controller
    {
        private IService<Pilot> Services { get; }

        public PilotsController(IService<Pilot> services) => Services = services;

        // GET api/Pilots
        [HttpGet]
        public List<Pilot> GetPilots() => Services.GetAll();

        // GET api/Pilots/5
        [HttpGet("{id}")]
        public ObjectResult GetPilotDetails(int id)
        {
            if (Services.IsExist(id) == null) return NotFound("Aircraft with id = " + id + " not found");
            return Ok(Services.GetDetails(id));
        }

        // POST api/Pilots
        [HttpPost]
        public ObjectResult PostPilot([FromBody]Pilot pilot)
        {
            Services.Add(pilot);
            return Ok(pilot);
        }

        // PUT api/Pilots/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutPilot(int id, [FromBody]Pilot pilot)
        {
            if (Services.IsExist(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Update(pilot);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Pilots/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeletePilot(int id)
        {
            if (Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Pilots
        [HttpDelete]
        public HttpResponseMessage DeletePilots()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
