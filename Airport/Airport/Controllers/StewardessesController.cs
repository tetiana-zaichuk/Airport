using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class StewardessesController : Controller
    {
        private IService<Stewardess> Services { get; }

        public StewardessesController(IService<Stewardess> services) => Services = services;

        // GET api/Stewardesses
        [HttpGet]
        public List<Stewardess> GetAircrafts() => Services.GetAll();

        // GET api/Stewardesses/5
        [HttpGet("{id}")]
        public ObjectResult GetAircraftDetails(int id)
        {
            if (Services.IsExist(id) == null) return NotFound("Aircraft with id = " + id + " not found");
            return Ok(Services.GetDetails(id));
        }

        // POST api/Stewardesses
        [HttpPost]
        public ObjectResult PostStewardess([FromBody]Stewardess stewardess)
        {
            Services.Add(stewardess);
            return Ok(stewardess);
        }

        // PUT api/Stewardesses/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutStewardess(int id, [FromBody]Stewardess stewardess)
        {
            if (Services.IsExist(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Update(stewardess);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Stewardesses/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteStewardess(int id)
        {
            if (Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Stewardesses
        [HttpDelete]
        public HttpResponseMessage DeleteStewardesses()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
