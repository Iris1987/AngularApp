
using BaseEntities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Repos
{
    public class CategoryRepo : IGeneric<Category>
    {
        private MyContext db;

        public CategoryRepo(MyContext context)
        {
            this.db = context;
        }

        public void Delete(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category != null)
                db.Categorys.Remove(category);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categorys.ToList();
        }

        public Category GetByID(int id)
        {
            return db.Categorys.FirstOrDefault(x => x.IdCategory == id);/*db.Categorys.Find(id);*/

        }

        public void Create(Category item)
        {
            db.Categorys.Add(item);
            Save();
        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public IEnumerable<CategoryRepo> Find(Expression<Func<CategoryRepo, bool>> predicate)
        {
            return db.Set<CategoryRepo>().Where(predicate);
        }
    }
}
