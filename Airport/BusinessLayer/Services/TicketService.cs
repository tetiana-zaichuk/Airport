using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class TicketService : IService<Ticket>
    {
        private readonly IRepository<DataAccessLayer.Models.Ticket> _repository;
        private readonly IRepository<DataAccessLayer.Models.Flight> _repositoryFlight;

        public TicketService(IRepository<DataAccessLayer.Models.Ticket> repository,
                        IRepository<DataAccessLayer.Models.Flight> repositoryFlight)
        {
            _repository = repository;
            _repositoryFlight = repositoryFlight;
        }

        public bool ValidationForeignId(Ticket ob)
            => _repositoryFlight.Get().FirstOrDefault(o => o.Id == ob.FlightId) != null;

        public Ticket IsExist(int id)
            => Mapper.Map<DataAccessLayer.Models.Ticket, Ticket>(_repository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Ticket ConvertToModel(Ticket ticket)
            => Mapper.Map<Ticket, DataAccessLayer.Models.Ticket>(ticket);

        public List<Ticket> GetAll()
            => Mapper.Map<List<DataAccessLayer.Models.Ticket>, List<Ticket>>(_repository.Get());

        public Ticket GetDetails(int id) => IsExist(id);

        public void Add(Ticket ticket) => _repository.Create(ConvertToModel(ticket));

        public void Update(Ticket ticket) => _repository.Update(ConvertToModel(ticket));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
