using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Services;
using Shared.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        private TicketService Services { get; }

        public TicketsController(TicketService services) => Services = services;

        // GET api/Tickets
        [HttpGet]
        public List<Ticket> GetTickets() => Services.GetTicket();

        // GET api/Tickets/5
        [HttpGet("{id}")]
        public ObjectResult GetTicketDetails(int id)
        {
            if (Services.IsTicket(id) == null) return NotFound("Aircraft with id = " + id + "not found");
            return Ok(Services.GetTicketDetails(id));
        }

        // POST api/Tickets
        [HttpPost]
        public ObjectResult PostTicket([FromBody]Ticket ticket)
        {
            Services.AddTicket(ticket);
            return Ok(ticket);
        }

        // PUT api/Tickets/5
        [HttpPut("{id}")]
        public HttpResponseMessage PutTicket(int id, [FromBody]Ticket ticket)
        {
            if (Services.IsTicket(id) == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.UpdateTicket(ticket);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE api/Tickets/5
        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteTicket(int id)
        {
            if (Services.IsTicket(id) == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            Services.RemoveTicket(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        // DELETE api/Tickets
        [HttpDelete]
        public HttpResponseMessage DeleteTickets()
        {
            Services.RemoveTickets();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
