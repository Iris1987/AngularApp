using BaseEntities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class PartOfSpeechService : IGenericService<PartOfSpeech>
    {
        private readonly IGeneric<PartOfSpeech> repository;


        public PartOfSpeechService(IGeneric<PartOfSpeech> repository)
        {

            this.repository = repository;

        }

        public void Create(PartOfSpeech item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<PartOfSpeech> Find(string word)
        {
            return repository.GetAll().Where(x => x.Partname.Equals(word));
        }

        public IEnumerable<PartOfSpeech> GetAll()
        {
            return repository.GetAll().OrderBy(x=>x.Partname);
        }

        public PartOfSpeech GetByID(int id)
        {
            return repository.GetByID(id);
        }

        public void Update(PartOfSpeech item)
        {
            repository.Update(item);
        }
    }
}
