using BaseEntities.Models;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class EngRusService : IGenericTranslate<TranslationEngRus>
    {
        private readonly IGeneric<TranslationEngRus> repository;


        public EngRusService(IGeneric<TranslationEngRus> repository)
        {

            this.repository = repository;

        }


        public void Create(TranslationEngRus item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
        //
        public IEnumerable<TranslationEngRus> Find(string word)
        {
            return repository.GetAll().Where(x => x.IdWordEngNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordRusNavigation.Word.ToLower().Contains(word.ToLower()));
        }

        public IEnumerable<TranslationEngRus> GetAll()
        {

            return repository.GetAll().OrderBy(x=>x.IdWordEngNavigation.Word);
        }

        public IEnumerable<TranslationEngRus> FindByCategory(int catID, string word)
        {
            return repository.GetAll().Where(x => x.IdCategoryNavigation.IdCategoryNavigation.IdCategory.Equals(catID) && x.IdWordEngNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordRusNavigation.Word.ToLower().Contains(word.ToLower()));
        }

        public IEnumerable<TranslationEngRus> FindByCatSubcat(int catID, int subcatID, string word)
        {
            return repository.GetAll().Where(x => x.IdCategoryNavigation.IdCategoryNavigation.IdCategory.Equals(catID) && x.IdCategoryNavigation.IdSubcategory.Equals(subcatID) && x.IdWordEngNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordRusNavigation.Word.ToLower().Contains(word.ToLower()));

        }

        public IEnumerable<TranslationEngRus> FindBySubcategory(int subcatID, string word)
        {
            return repository.GetAll().Where(x => x.IdCategoryNavigation.IdSubcategory.Equals(subcatID) && x.IdWordEngNavigation.Word.ToLower().Contains(word.ToLower()) || x.IdWordRusNavigation.Word.ToLower().Contains(word.ToLower()));

        }

        // В таблице перевода idcategory относится к подкатегории (idsubcategory)
        public IEnumerable<TranslationEngRus> GetByCategory(int id)
        {
            return repository.GetAll().Where(z => z.IdCategoryNavigation.IdCategoryNavigation.IdCategory.Equals(id));
        }

        public TranslationEngRus GetByID(int id)
        {

            var engest = repository.GetByID(id);
            return engest;
        }

        public IEnumerable<TranslationEngRus> GetBySubcategory(int id)
        {
            return repository.GetAll().Where(y => y.IdCategoryNavigation.IdSubcategory.Equals(id));


        }

        public void Update(TranslationEngRus item)
        {
            repository.Update(item);
        }
    }
}
