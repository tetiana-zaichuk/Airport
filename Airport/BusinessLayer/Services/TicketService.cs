using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Model = DataAccessLayer.Models;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class TicketService : IService<Ticket>
    {
        private readonly IRepository<Model.Ticket> _repository;
        private readonly IRepository<Model.Flight> _repositoryFlight;

        public TicketService(IRepository<Model.Ticket> repository, IRepository<Model.Flight> repositoryFlight)
        {
            _repository = repository;
            _repositoryFlight = repositoryFlight;
        }

        public bool ValidationForeignId(Ticket ob) => _repositoryFlight.Get().FirstOrDefault(o => o.Id == ob.FlightId) != null;

        public Ticket IsExist(int id) => Mapper.Map<Model.Ticket, Ticket>(_repository.Get(id).FirstOrDefault());

        public Model.Ticket ConvertToModel(Ticket ticket) => Mapper.Map<Ticket, Model.Ticket>(ticket);

        public List<Ticket> GetAll() => Mapper.Map<List<Model.Ticket>, List<Ticket>>(_repository.Get());

        public Ticket GetDetails(int id) => IsExist(id);

        public void Add(Ticket ticket) => _repository.Create(ConvertToModel(ticket));

        public void Update(Ticket ticket) => _repository.Update(ConvertToModel(ticket));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
