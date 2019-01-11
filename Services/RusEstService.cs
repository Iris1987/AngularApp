using BaseEntities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class RusEstService : IGenericTranslate<TranslationRusEst>
    {

        private readonly IGeneric<TranslationRusEst> repository;


        public RusEstService(IGeneric<TranslationRusEst> repository)
        {

            this.repository = repository;

        }


        public void Create(TranslationRusEst item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
        //
        public IEnumerable<TranslationRusEst> Find(string word)
        {
            return repository.GetAll().Where(x => x.IdWordRusNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordEstNavigation.Word.ToLower().Contains(word.ToLower()));
        }

        public IEnumerable<TranslationRusEst> GetAll()
        {

            return repository.GetAll().OrderBy(x=>x.IdWordRusNavigation.Word);
        }

        public IEnumerable<TranslationRusEst> FindByCategory(int catID, string word)
        {
            return repository.GetAll().Where(x => x.IdCategoryNavigation.IdCategoryNavigation.IdCategory.Equals(catID) && x.IdWordRusNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordEstNavigation.Word.ToLower().Contains(word.ToLower()));
        }

        public IEnumerable<TranslationRusEst> FindByCatSubcat(int catID, int subcatID, string word)
        {
            return repository.GetAll().Where(x => x.IdCategoryNavigation.IdCategoryNavigation.IdCategory.Equals(catID) && x.IdCategoryNavigation.IdSubcategory.Equals(subcatID) && x.IdWordRusNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordEstNavigation.Word.ToLower().Contains(word.ToLower()));

        }

        public IEnumerable<TranslationRusEst> FindBySubcategory(int subcatID, string word)
        {
            return repository.GetAll().Where(x => x.IdCategoryNavigation.IdSubcategory.Equals(subcatID) && x.IdWordRusNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordEstNavigation.Word.ToLower().Contains(word.ToLower()));

        }

        // В таблице перевода idcategory относится к подкатегории (idsubcategory)
        public IEnumerable<TranslationRusEst> GetByCategory(int id)
        {
            return repository.GetAll().Where(z => z.IdCategoryNavigation.IdCategoryNavigation.IdCategory.Equals(id));
        }

        public TranslationRusEst GetByID(int id)
        {

            var engest = repository.GetByID(id);
            return engest;
        }

        public IEnumerable<TranslationRusEst> GetBySubcategory(int id)
        {
            return repository.GetAll().Where(y => y.IdCategoryNavigation.IdSubcategory.Equals(id));


        }

        public void Update(TranslationRusEst item)
        {
            repository.Update(item);
        }

    }
}
