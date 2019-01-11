using BaseEntities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repos
{
    public class RusRepo : IGeneric<LangRussian>
    {
        private MyContext db;

        public RusRepo(MyContext context)
        {
            this.db = context;
        }

        public void Delete(int id)
        {
            LangRussian rusLang = db.LangRussians.Find(id);
            if (rusLang != null)
                db.LangRussians.Remove(rusLang);
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

        public IEnumerable<LangRussian> GetAll()
        {
            return db.LangRussians.ToList();
        }

        public LangRussian GetByID(int id)
        {
            return db.LangRussians.FirstOrDefault(x => x.IdWord == id); /*db.LangRussians.Find(id);*/
        }

        public void Create(LangRussian item)
        {
            db.LangRussians.Add(item);
            Save();
        }

        public void Update(LangRussian item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

    }
}
