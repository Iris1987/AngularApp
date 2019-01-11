using BaseEntities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class RusService : IGenericService<LangRussian>
    {
        private readonly IGeneric<LangRussian> repository;


        public RusService(IGeneric<LangRussian> repository)
        {

            this.repository = repository;

        }

        public void Create(LangRussian item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<LangRussian> Find(string word)
        {
            return repository.GetAll().Where(x => x.Word.ToLower().Contains(word.ToLower()));
        }

        public IEnumerable<LangRussian> GetAll()
        {
            return repository.GetAll().OrderBy(x=>x.Word);
        }

        public LangRussian GetByID(int id)
        {
            return repository.GetByID(id);
        }

        public void Update(LangRussian item)
        {
            repository.Update(item);
        }
    }
}
