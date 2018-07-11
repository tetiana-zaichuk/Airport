using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class StewardessesController : Controller
    {
        private StewardessService Services { get; }

        public StewardessesController(StewardessService services) => Services = services;

        // GET api/Stewardesses
        [HttpGet]
        public List<Stewardess> GetAircrafts() => Services.GetStewardesses();

        // GET api/Stewardesses/5
        [HttpGet("{id}")]
        public ObjectResult GetAircraftDetails(int id)
        {
            if (Services.IsStewardess(id) == null) return NotFound("Aircraft with id = " + id + "not found");
            return Ok(Services.GetStewardessDetails(id));
        }

        // POST api/Stewardesses
        [HttpPost]
        public ObjectResult PostStewardess([FromBody]Stewardess stewardess)
        {
            Services.AddStewardess(stewardess);
            return Ok(stewardess);
        }

        // PUT api/Stewardesses/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutStewardess(int id, [FromBody]Stewardess stewardess)
        {
            if (Services.IsStewardess(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.UpdateStewardess(stewardess);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Stewardesses/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteStewardess(int id)
        {
            if (Services.IsStewardess(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.RemoveStewardess(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Stewardesses
        [HttpDelete]
        public HttpResponseMessage DeleteStewardesses()
        {
            Services.RemoveStewardesses();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
