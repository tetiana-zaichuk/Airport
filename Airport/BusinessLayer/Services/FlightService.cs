using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class FlightService : IService<Flight>
    {
        private readonly IRepository<DataAccessLayer.Models.Flight> _repository;
        private readonly IRepository<DataAccessLayer.Models.Ticket> _repositoryTicket;

        public FlightService(IRepository<DataAccessLayer.Models.Flight> repository,
            IRepository<DataAccessLayer.Models.Ticket> repositoryTicket)
        {
            _repository = repository;
            _repositoryTicket = repositoryTicket;
        }

        public bool ValidationForeignId(Flight ob)
        {
            foreach (var t in ob.TicketsId)
            {
                if (_repositoryTicket.Get(t).FirstOrDefault() == null) return false;
            }
            return true;
        }

        public Flight IsExist(int id) => Mapper.Map<DataAccessLayer.Models.Flight, Flight>(_repository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Flight ConvertToModel(Flight flight) => Mapper.Map<Flight, DataAccessLayer.Models.Flight>(flight);
        
        public List<Flight> GetAll() => Mapper.Map<List<DataAccessLayer.Models.Flight>, List<Flight>>(_repository.Get());

        public Flight GetDetails(int id) => IsExist(id);

        public void Add(Flight flight) => _repository.Create(ConvertToModel(flight));

        public void Update(Flight flight) => _repository.Update(ConvertToModel(flight));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
