using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class DepartureService : IService<Departure>
    {
        private readonly IRepository<DataAccessLayer.Models.Departure> _repository;

        public DepartureService(IRepository<DataAccessLayer.Models.Departure> repository)
            => _repository = repository;

        public Departure IsExist(int id)
            => Mapper.Map<DataAccessLayer.Models.Departure, Departure>(_repository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Departure ConvertToModel(Departure departure)
            => Mapper.Map<Departure, DataAccessLayer.Models.Departure>(departure);

        public List<Departure> GetAll()
            => Mapper.Map<List<DataAccessLayer.Models.Departure>, List<Departure>>(_repository.Get());

        public Departure GetDetails(int id) => IsExist(id);

        public void Add(Departure departure) => _repository.Create(ConvertToModel(departure));

        public void Update(Departure departure) => _repository.Update(ConvertToModel(departure));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
