using BaseEntities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repos
{
    public class EngEstRepo : IGeneric<TranslationEngEst>
    {
        private MyContext db;

        public EngEstRepo(MyContext context)
        {
            this.db = context;
        }

        public void Delete(int id)
        {
            TranslationEngEst engEst = db.TranslationEngEsts.Find(id);


            if (engEst != null)
                db.TranslationEngEsts.Remove(engEst);
            Save();
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is TranslationEngEst)
                    {
                        // Using a NoTracking query means we get the entity but it is not tracked by the context
                        // and will not be merged with existing entities in the context.
                        
                        var databaseEntity = db.TranslationEngEsts.AsNoTracking().Single(p => p.IdTranslation == ((TranslationEngEst)entry.Entity).IdTranslation);
                        var databaseEntry = db.Entry(databaseEntity);

                        foreach (var property in entry.Metadata.GetProperties())
                        {
                            var proposedValue = entry.Property(property.Name).CurrentValue;
                            var originalValue = entry.Property(property.Name).OriginalValue;
                            var databaseValue = databaseEntry.Property(property.Name).CurrentValue;

                            // TODO: Logic to decide which value should be written to database
                            // entry.Property(property.Name).CurrentValue = <value to be saved>;

                            entry.Property(property.Name).CurrentValue = 

                            // Update original values to
                            entry.Property(property.Name).OriginalValue = databaseEntry.Property(property.Name).CurrentValue;
                        }
                    }
                    else
                    {
                        throw new NotSupportedException("Don't know how to handle concurrency conflicts for " + entry.Metadata.Name);
                    }
                }

                // Retry the save operation
                db.SaveChanges();
            }
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

        public IEnumerable<TranslationEngEst> GetAll()
        {
            return db.TranslationEngEsts.Include(x => x.IdCategoryNavigation)
                .Include(x => x.IdPartNavigation)
                .Include(x => x.IdWordEngNavigation)
                .Include(x => x.IdWordEstNavigation)
                .Include(x => x.IdCategoryNavigation.IdCategoryNavigation).ToList();
        }

        public TranslationEngEst GetByID(int id)
        {
            return db.TranslationEngEsts.FirstOrDefault(x => x.IdTranslation == id); /*db.TranslationEngEsts.Find(id);*/
        }

        public void Create(TranslationEngEst item)
        {
            db.TranslationEngEsts.Add(item);
            Save();
        }

        public void Update(TranslationEngEst item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }
    }
}
