using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IGeneric<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        void Save();




    }
}
