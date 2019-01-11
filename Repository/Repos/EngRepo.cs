using BaseEntities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repos
{
    public class EngRepo : IGeneric<LangEnglish>
    {
        private MyContext db;

        public EngRepo(MyContext context)
        {
            this.db = context;
        }

        public void Delete(int id)
        {
            LangEnglish engLang = db.LangEnglishs.Find(id);
            if (engLang != null)
                db.LangEnglishs.Remove(engLang);
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

        public IEnumerable<LangEnglish> GetAll()
        {
            return db.LangEnglishs.ToList();
        }

        public LangEnglish GetByID(int id)
        {
            return db.LangEnglishs.FirstOrDefault(x => x.IdWord == id);/*db.LangEnglishs.Find(id);*/
        }

        public void Create(LangEnglish item)
        {
            db.LangEnglishs.Add(item);
            Save();
        }

        public void Update(LangEnglish item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}
