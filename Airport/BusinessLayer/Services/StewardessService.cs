using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Model = DataAccessLayer.Models;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class StewardessService : IService<Stewardess>
    {
        private readonly IRepository<Model.Stewardess> _repository;

        public StewardessService(IRepository<Model.Stewardess> repository) => _repository = repository;

        public bool ValidationForeignId(Stewardess ob) => true;

        public Stewardess IsExist(int id) => Mapper.Map<Model.Stewardess, Stewardess>(_repository.Get(id).FirstOrDefault());

        public Model.Stewardess ConvertToModel(Stewardess stewardess) => Mapper.Map<Stewardess, Model.Stewardess>(stewardess);

        public List<Stewardess> GetAll() => Mapper.Map<List<Model.Stewardess>, List<Stewardess>>(_repository.Get());

        public Stewardess GetDetails(int id) => IsExist(id);

        public void Add(Stewardess stewardess) => _repository.Create(ConvertToModel(stewardess));

        public void Update(Stewardess stewardess) => _repository.Update(ConvertToModel(stewardess));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
