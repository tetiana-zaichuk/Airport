using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Model = DataAccessLayer.Models;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class PilotService : IService<Pilot>
    {
        private readonly IRepository<Model.Pilot> _repository;

        public PilotService(IRepository<Model.Pilot> repository) => _repository = repository;

        public bool ValidationForeignId(Pilot ob) => true;

        public Pilot IsExist(int id) => Mapper.Map<Model.Pilot, Pilot>(_repository.Get(id).FirstOrDefault());

        public Model.Pilot ConvertToModel(Pilot pilot) => Mapper.Map<Pilot, Model.Pilot>(pilot);

        public List<Pilot> GetAll() => Mapper.Map<List<Model.Pilot>, List<Pilot>>(_repository.Get());

        public Pilot GetDetails(int id) => IsExist(id);

        public void Add(Pilot pilot) => _repository.Create(ConvertToModel(pilot));

        public void Update(Pilot pilot) => _repository.Update(ConvertToModel(pilot));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
