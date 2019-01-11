using BaseEntities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class SubcategoryService : IGenericService<Subcategory>
    {
        private readonly IGeneric<Subcategory> repository;


        public SubcategoryService(IGeneric<Subcategory> repository)
        {

            this.repository = repository;

        }

        public void Create(Subcategory item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Subcategory> Find(string word)
        {
            return repository.GetAll().Where(x => x.Subcategoryname.Equals(word));
        }

        public IEnumerable<Subcategory> GetAll()
        {
            return repository.GetAll().OrderBy(x=>x.Subcategoryname);
        }

        public Subcategory GetByID(int id)
        {
            return repository.GetByID(id);
        }

        public void Update(Subcategory item)
        {
            repository.Update(item);
        }
    }
}
