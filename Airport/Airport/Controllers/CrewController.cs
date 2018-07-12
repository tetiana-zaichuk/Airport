using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class CrewController : Controller
    {
        private IService<Crew> Services { get; }

        public CrewController(IService<Crew> services) => Services = services;

        // GET api/Crew
        [HttpGet]
        public List<Crew> GetCrews() => Services.GetAll();

        // GET api/Crew/5
        [HttpGet("{id}")]
        public ObjectResult GetCrewDetails(int id)
        {
            if (Services.IsExist(id) == null) return NotFound("Crew with id = " + id + " not found");
            return Ok(Services.GetDetails(id));
        }

        // POST api/Crew
        [HttpPost]
        public ObjectResult PostCrew([FromBody]Crew crew)
        {
            Services.Add(crew);
            return Ok(crew);
        }

        // PUT api/Crew/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutCrew(int id, [FromBody]Crew crew)
        {
            if (Services.IsExist(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Update(crew);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Crew/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteCrew(int id)
        {
            if (Services.IsExist(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Crew
        [HttpDelete]
        public HttpResponseMessage DeleteCrews()
        {
            Services.RemoveAll();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
