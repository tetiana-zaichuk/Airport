using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airport.Model;
using Microsoft.CodeAnalysis.CSharp;
using PresentationLayer.Model;

namespace PresentationLayer
{
    public class Seeds
    {
        public static List<Aircraft> Aircraft = new List<Aircraft>()
            { new Aircraft(){Id = 1, AircraftName = "Strong", AircraftTypeId = 1, AircraftReleaseDate = new DateTime(2011, 6, 10),
                ExploitationTimeSpan = new DateTime(2021, 6, 10)-new DateTime(2011, 6, 10)},
              new Aircraft(){Id = 2, AircraftName = "Dog", AircraftTypeId = 2, AircraftReleaseDate = new DateTime(2011, 6, 10),
                    ExploitationTimeSpan = new DateTime(2021, 6, 10)-new DateTime(2011, 6, 10)}
            };

        public static List<AircraftType> AircraftTypes=new List<AircraftType>()
        {
            new AircraftType(){Id = 1,AircraftModel = "Tupolev Tu-134",SeatsNumber = 80,Carrying = 47000},
            new AircraftType(){Id = 2,AircraftModel = "Tupolev Tu-204",SeatsNumber = 196,Carrying = 107900},
            new AircraftType(){Id = 3,AircraftModel = "Ilyushin IL-62",SeatsNumber = 138,Carrying = 280300}
        };

        public static List<Flight> Flights=new List<Flight>()
        {
            new Flight(){Id = 1,Departure = "Kiev",DepartureTime = new DateTime(2018,7,15,19,35,00),
                Destination = "Tbilisi",ArrivalTime = new DateTime(2018,7,15,21,52,00)},
            new Flight(){Id = 1,Departure = "Venezia",DepartureTime = new DateTime(2018,7,17,13,25,00),
                Destination = "Kiev",ArrivalTime = new DateTime(2018,7,17,16,00,00)}
        };

        public static List<Departure> Departures = new List<Departure>()
        {
            new Departure(){Id = 1,FlightId = 1,AircraftId = 1,CrewId = 1,DepartureDate = new DateTime(2018,7,15,19,35,00)},
            new Departure(){Id = 2,FlightId = 2,AircraftId = 2,CrewId = 2,DepartureDate = new DateTime(2018,7,17,14,25,00)}
        };

        public static List<Pilot> Pilots=new List<Pilot>()
        {
            new Pilot(){Id = 1,FirstName = "",LastName = "",Dob = new DateTime(1978,03,03),Experience = 9},
            new Pilot(){Id = 2,FirstName = "",LastName = "",Dob = new DateTime(1983,07,11),Experience = 5}
        };

        public static List<Stewardess> Stewardesses = new List<Stewardess>()
        {
            new Stewardess(){Id = 1,FirstName = "",LastName = "",Dob = new DateTime(1993,02,03)},
            new Stewardess(){Id = 2,FirstName = "",LastName = "",Dob = new DateTime(1987,11,10)}
        };

        public static List<Ticket> Tickets = new List<Ticket>()
        {           
            new Ticket(){Id = 1,FlightId = 1,Price = 5000},
            new Ticket(){Id = 2,FlightId = 2,Price = 3500}
        };

        //List<Crew> 
    }
}
