using BaseEntities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repos
{
    public class EstRepo : IGeneric<LangEstonian>
    {
        private MyContext db;

        public EstRepo(MyContext context)
        {
            this.db = context;
        }

        public void Delete(int id)
        {
            LangEstonian estLang = db.LangEstonians.Find(id);
            if (estLang != null)
                db.LangEstonians.Remove(estLang);
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

        public IEnumerable<LangEstonian> GetAll()
        {
            return db.LangEstonians.ToList();
        }

        public LangEstonian GetByID(int id)
        {
            return db.LangEstonians.FirstOrDefault(x => x.IdWord == id); /*db.LangEstonians.Find(id);*/
        }

        public void Create(LangEstonian item)
        {
            db.LangEstonians.Add(item);
            Save();
        }

        public void Update(LangEstonian item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}
