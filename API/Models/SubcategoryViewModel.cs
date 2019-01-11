using BaseEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class SubcategoryViewModel
    {
        public int IdSubcategory { get; set; }
        public string Subcategoryname { get; set; }
        public int IdCategory { get; set; }

        public CategoryViewModel IdCategoryNavigation { get; set; }
        public ICollection<EngEstViewModel> TranslationEngEst { get; set; }
        public ICollection<EngRusViewModel> TranslationEngRus { get; set; }
        public ICollection<RusEstViewModel> TranslationRusEst { get; set; }


        //public static implicit operator SubcategoryViewModel(Subcategory sub)
        //{
        //    return new SubcategoryViewModel
        //    {
        //        IdSubcategory = sub.IdSubcategory,
        //        Subcategoryname = sub.Subcategoryname,
        //        IdCategory = sub.IdCategory,

        //        IdCategoryNavigation = sub.IdCategoryNavigation

        //    };
        //}

        //public static implicit operator Subcategory(SubcategoryViewModel suby)
        //{
        //    return new SubcategoryViewModel
        //    {
        //        IdSubcategory = suby.IdSubcategory,
        //        Subcategoryname = suby.Subcategoryname,
        //        IdCategory = suby.IdCategory,

        //        IdCategoryNavigation = suby.IdCategoryNavigation

        //    };
        //}
    }
}
