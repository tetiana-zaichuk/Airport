using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class FlightService
    {
        public DataAccessLayer.Models.Flight IsFlight(int id)
            => DataSeends.Flights.FirstOrDefault(a => a.Id == id);

        public List<Flight> GetFlight()
            => Mapper.Map<List<DataAccessLayer.Models.Flight>, List<Flight>>(DataSeends.Flights);

        public Flight GetFlightDetails(int id)
            => Mapper.Map<DataAccessLayer.Models.Flight, Flight>(IsFlight(id));

        public void AddFlight(Flight flight)
            => DataSeends.Flights.Add(Mapper.Map<Flight, DataAccessLayer.Models.Flight>(flight));

        public void UpdateFlight(Flight flight)
        {
            var fl = IsFlight(flight.Id);
            fl.Departure = flight.Departure;
            fl.DepartureTime = flight.DepartureTime;
            fl.Destination = flight.Destination;
            fl.ArrivalTime = flight.ArrivalTime;
            fl.Tickets = Mapper.Map<List<Ticket>, List<DataAccessLayer.Models.Ticket>>(flight.Tickets);
        }

        public void RemoveFlight(int id) => DataSeends.Flights.Remove(IsFlight(id));

        public void RemoveFlights() => DataSeends.Flights.Clear();
    }
}
