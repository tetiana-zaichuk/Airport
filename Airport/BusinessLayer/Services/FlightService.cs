using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Model = DataAccessLayer.Models;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class FlightService : IService<Flight>
    {
        private readonly IRepository<Model.Flight> _repository;
        private readonly IRepository<Model.Ticket> _repositoryTicket;

        public FlightService(IRepository<Model.Flight> repository, IRepository<Model.Ticket> repositoryTicket)
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

        public Flight IsExist(int id) => Mapper.Map<Model.Flight, Flight>(_repository.Get(id).FirstOrDefault());

        public Model.Flight ConvertToModel(Flight flight) => Mapper.Map<Flight, Model.Flight>(flight);
        
        public List<Flight> GetAll() => Mapper.Map<List<Model.Flight>, List<Flight>>(_repository.Get());

        public Flight GetDetails(int id) => IsExist(id);

        public void Add(Flight flight) => _repository.Create(ConvertToModel(flight));

        public void Update(Flight flight) => _repository.Update(ConvertToModel(flight));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
