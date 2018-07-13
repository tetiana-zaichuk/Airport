using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class PilotService : IService<Pilot>
    {
        private readonly IRepository<DataAccessLayer.Models.Pilot> _repository;

        public PilotService(IRepository<DataAccessLayer.Models.Pilot> repository)
            => _repository = repository;

        public bool ValidationForeignId(Pilot ob) => true;

        public Pilot IsExist(int id)
            => Mapper.Map<DataAccessLayer.Models.Pilot, Pilot>(_repository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Pilot ConvertToModel(Pilot pilot)
            => Mapper.Map<Pilot, DataAccessLayer.Models.Pilot>(pilot);

        public List<Pilot> GetAll()
            => Mapper.Map<List<DataAccessLayer.Models.Pilot>, List<Pilot>>(_repository.Get());

        public Pilot GetDetails(int id) => IsExist(id);

        public void Add(Pilot pilot) => _repository.Create(ConvertToModel(pilot));

        public void Update(Pilot pilot) => _repository.Update(ConvertToModel(pilot));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
