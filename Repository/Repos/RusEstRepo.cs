using BaseEntities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repos
{
    public class RusEstRepo : IGeneric<TranslationRusEst>
    {
        private MyContext db;

        public RusEstRepo(MyContext context)
        {
            this.db = context;
        }

        public void Delete(int id)
        {
            TranslationRusEst translrusEst = db.TranslationRusEsts.Find(id);
            if (translrusEst != null)
                db.TranslationRusEsts.Remove(translrusEst);
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

        public IEnumerable<TranslationRusEst> GetAll()
        {
            return db.TranslationRusEsts.Include(x => x.IdCategoryNavigation)
                .Include(x => x.IdPartNavigation)
                .Include(x => x.IdWordRusNavigation)
                .Include(x => x.IdWordEstNavigation)
                .Include(x => x.IdCategoryNavigation.IdCategoryNavigation)
                .ToList();
        }

        public TranslationRusEst GetByID(int id)
        {
            return db.TranslationRusEsts.FirstOrDefault(x => x.IdTranslation == id);/*db.TranslationRusEsts.Find(id);*/
        }

        public void Create(TranslationRusEst item)
        {
            db.TranslationRusEsts.Add(item);
            Save();
        }

        public void Update(TranslationRusEst item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

    }
}
