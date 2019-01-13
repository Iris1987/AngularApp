using BaseEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class SubcategoryViewModel
    {

        public SubcategoryViewModel()
        {
            TranslationEngEst = new HashSet<EngEstViewModel>();
            TranslationEngRus = new HashSet<EngRusViewModel>();
            TranslationRusEst = new HashSet<RusEstViewModel>();
        }

        public int IdSubcategory { get; set; }
        public string Subcategoryname { get; set; }
        public int IdCategory { get; set; }

        public CategoryViewModel IdCategoryNavigation { get; set; }
        public ICollection<EngEstViewModel> TranslationEngEst { get; set; }
        public ICollection<EngRusViewModel> TranslationEngRus { get; set; }
        public ICollection<RusEstViewModel> TranslationRusEst { get; set; }
    }
}
