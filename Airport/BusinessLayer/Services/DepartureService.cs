using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Model = DataAccessLayer.Models;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class DepartureService : IService<Departure>
    {
        private readonly IRepository<Model.Departure> _repository;
        private readonly IRepository<Model.Aircraft> _repositoryAircraft;
        private readonly IRepository<Model.Crew> _repositoryCrew;
        private readonly IRepository<Model.Flight> _repositoryFlight;

        public DepartureService(IRepository<Model.Departure> repository, IRepository<Model.Aircraft> repositoryAircraft, 
            IRepository<Model.Crew> repositoryCrew, IRepository<Model.Flight> repositoryFlight)
        {
            _repository = repository;
            _repositoryAircraft = repositoryAircraft;
            _repositoryCrew = repositoryCrew;
            _repositoryFlight = repositoryFlight;
        }

        public bool ValidationForeignId(Departure ob)
        {
             return _repositoryAircraft.Get().FirstOrDefault(o => o.Id == ob.AircraftId) != null &&
            _repositoryCrew.Get().FirstOrDefault(o => o.Id == ob.CrewId) != null &&
            _repositoryFlight.Get().FirstOrDefault(o => o.Id == ob.FlightId) != null;
        }

        public Departure IsExist(int id) => Mapper.Map<Model.Departure, Departure>(_repository.Get(id).FirstOrDefault());

        public Model.Departure ConvertToModel(Departure departure) => Mapper.Map<Departure, Model.Departure>(departure);

        public List<Departure> GetAll() => Mapper.Map<List<Model.Departure>, List<Departure>>(_repository.Get());

        public Departure GetDetails(int id) => IsExist(id);

        public void Add(Departure departure) => _repository.Create(ConvertToModel(departure));

        public void Update(Departure departure) => _repository.Update(ConvertToModel(departure));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
