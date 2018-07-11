using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class CrewController : Controller
    {
        private CrewService Services { get; }

        public CrewController(CrewService services) => Services = services;

        // GET api/Crew
        [HttpGet]
        public List<Crew> GetCrews() => Services.GetCrew();

        // GET api/Crew/5
        [HttpGet("{id}")]
        public ObjectResult GetCrewDetails(int id)
        {
            if (Services.IsCrew(id) == null) return NotFound("Crew with id = " + id + "not found");
            return Ok(Services.GetCrewDetails(id));
        }

        // POST api/Crew
        [HttpPost]
        public ObjectResult PostCrew([FromBody]Crew crew)
        {
            Services.AddCrew(crew);
            return Ok(crew);
        }

        // PUT api/Crew/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutCrew(int id, [FromBody]Crew crew)
        {
            if (Services.IsCrew(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.UpdateCrew(crew);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Crew/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteCrew(int id)
        {
            if (Services.IsCrew(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.RemoveCrew(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Crew
        [HttpDelete]
        public HttpResponseMessage DeleteCrews()
        {
            Services.RemoveCrews();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
