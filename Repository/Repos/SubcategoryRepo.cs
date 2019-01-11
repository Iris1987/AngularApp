using BaseEntities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repos
{
    public class SubcategoryRepo : IGeneric<Subcategory>
    {
        private MyContext db;

        public SubcategoryRepo(MyContext context)
        {
            this.db = context;
        }

        public void Delete(int id)
        {
            Subcategory subCategory = db.Subcategorys.Find(id);
            if (subCategory != null)
                db.Subcategorys.Remove(subCategory);
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

        public IEnumerable<Subcategory> GetAll()
        {
            return db.Subcategorys
                .Include(x=>x.IdCategoryNavigation)
                .ToList();
        }

        public Subcategory GetByID(int id)
        {
            return db.Subcategorys.FirstOrDefault(x => x.IdSubcategory == id);/*db.Subcategorys.Find(id);*/
        }

        public void Create(Subcategory item)
        {
            db.Subcategorys.Add(item);
            Save();
        }

        public void Update(Subcategory item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

       
    }
}
