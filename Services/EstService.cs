using BaseEntities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class EstService : IGenericService<LangEstonian>
    {
        private readonly IGeneric<LangEstonian> repository;


        public EstService(IGeneric<LangEstonian> repository)
        {

            this.repository = repository;

        }

        public void Create(LangEstonian item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<LangEstonian> Find(string word)
        {
            return repository.GetAll().Where(x => x.Word.ToLower().Contains(word.ToLower()));
        }

        public IEnumerable<LangEstonian> GetAll()
        {
            return repository.GetAll().OrderBy(x=>x.Word);
        }

        public LangEstonian GetByID(int id)
        {
            return repository.GetByID(id);
        }

        public void Update(LangEstonian item)
        {
            repository.Update(item);
        }
    }
}
