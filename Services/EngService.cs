using BaseEntities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class EngService : IGenericService<LangEnglish>
    {
        private readonly IGeneric<LangEnglish> repository;


        public EngService(IGeneric<LangEnglish> repository)
        {

            this.repository = repository;

        }

        public void Create(LangEnglish item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<LangEnglish> Find(string word)
        {
            return repository.GetAll().Where(x => x.Word.ToLower().Contains(word.ToLower()));
        }

        public IEnumerable<LangEnglish> GetAll()
        {
            return repository.GetAll().OrderBy(x=>x.Word);
        }

        public LangEnglish GetByID(int id)
        {
            return repository.GetByID(id);
        }

        public void Update(LangEnglish item)
        {
            repository.Update(item);
        }
    }
}
