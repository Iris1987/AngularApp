using BaseEntities.Models;
using Repository.Interfaces;

using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class EngEstService : IGenericTranslate<TranslationEngEst>
    {
        private readonly IGeneric<TranslationEngEst> repository;
        

        public EngEstService(IGeneric<TranslationEngEst> repository   )
        {

            this.repository = repository;

        }


        public void Create(TranslationEngEst item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
        //
        public IEnumerable<TranslationEngEst> Find(string word)
        {
             return repository.GetAll().Where(x => x.IdWordEngNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordEstNavigation.Word.ToLower().Contains(word.ToLower()));
        }
        public IEnumerable<TranslationEngEst> FindByCategory(int catID, string word)
        {
            return repository.GetAll().Where(x => x.IdCategoryNavigation.IdCategoryNavigation.IdCategory.Equals(catID) && x.IdWordEngNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordEstNavigation.Word.ToLower().Contains(word.ToLower()));
        }

        public IEnumerable<TranslationEngEst> FindByCatSubcat(int catID, int subcatID, string word)
        {
            return repository.GetAll().Where(x => x.IdCategoryNavigation.IdCategoryNavigation.IdCategory.Equals(catID) && x.IdCategoryNavigation.IdSubcategory.Equals(subcatID) && x.IdWordEngNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordEstNavigation.Word.ToLower().Contains(word.ToLower()));

        }

        public IEnumerable<TranslationEngEst> FindBySubcategory(int subcatID, string word)
        {
            return repository.GetAll().Where(x => x.IdCategoryNavigation.IdSubcategory.Equals(subcatID) && x.IdWordEngNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordEstNavigation.Word.ToLower().Contains(word.ToLower()));

        }
        public IEnumerable<TranslationEngEst> GetAll()
        {
            
                return repository.GetAll().OrderBy(x=>x.IdWordEngNavigation.Word);
        }
        
        // В таблице перевода idcategory относится к подкатегории (idsubcategory)
        public IEnumerable<TranslationEngEst> GetByCategory(int id)
        {
            return repository.GetAll().Where(z => z.IdCategoryNavigation.IdCategoryNavigation.IdCategory.Equals(id));
        }

        public TranslationEngEst GetByID(int id)
        { 

            return repository.GetByID(id);
             
        }

        public IEnumerable<TranslationEngEst> GetBySubcategory(int id)
        {
            return repository.GetAll().Where(y => y.IdCategoryNavigation.IdSubcategory.Equals(id)); 
                
     
        }

        public void Update(TranslationEngEst item)
        {
            repository.Update(item);
        }
    }
}
