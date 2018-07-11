using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class TicketService
    {
        public DataAccessLayer.Models.Ticket IsTicket(int id)
            => DataSeends.Tickets.FirstOrDefault(a => a.Id == id);

        public List<Ticket> GetTicket()
            => Mapper.Map<List<DataAccessLayer.Models.Ticket>, List<Ticket>>(DataSeends.Tickets);

        public Ticket GetTicketDetails(int id)
            => Mapper.Map<DataAccessLayer.Models.Ticket, Ticket>(IsTicket(id));

        public void AddTicket(Ticket ticket)
            => DataSeends.Tickets.Add(Mapper.Map<Ticket, DataAccessLayer.Models.Ticket>(ticket));

        public void UpdateTicket(Ticket ticket)
        {
            var t = IsTicket(ticket.Id);
            t.FlightId = ticket.FlightId;
            t.Price = ticket.Price;
        }

        public void RemoveTicket(int id) => DataSeends.Tickets.Remove(IsTicket(id));

        public void RemoveTickets() => DataSeends.Tickets.Clear();
    }
}
