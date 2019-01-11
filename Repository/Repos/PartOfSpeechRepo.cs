using BaseEntities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repos
{
    public class PartOfSpeechRepo : IGeneric<PartOfSpeech>
    {
        private MyContext db;

        public PartOfSpeechRepo(MyContext context)
        {
            this.db = context;
        }

        public void Delete(int id)
        {
            PartOfSpeech partofSpeech = db.PartOfSpeechs.Find(id);
            if (partofSpeech != null)
                db.PartOfSpeechs.Remove(partofSpeech);
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

        public IEnumerable<PartOfSpeech> GetAll()
        {
            return db.PartOfSpeechs.ToList();
        }

        public PartOfSpeech GetByID(int id)
        {
            return db.PartOfSpeechs.FirstOrDefault(x => x.IdPart == id); /*db.PartOfSpeechs.Find(id);*/
        }

        public void Create(PartOfSpeech item)
        {
            db.PartOfSpeechs.Add(item);
            Save();
        }

        public void Update(PartOfSpeech item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        
    }
}
