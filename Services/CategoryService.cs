using BaseEntities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class CategoryService : IGenericService<Category>
    {

        private readonly IGeneric<Category> repository;


        public CategoryService(IGeneric<Category> repository)
        {

            this.repository = repository;

        }

        public void Create(Category item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Category> Find(string word)
        {
            return repository.GetAll().Where(x => x.Categoryname.Equals(word));
        }

        public IEnumerable<Category> GetAll()
        {
            return repository.GetAll().OrderBy(x=>x.Categoryname);
        }

        public Category GetByID(int id)
        {
            return repository.GetByID(id);
        }

        public void Update(Category item)
        {
            repository.Update(item);
        }
    }
}

