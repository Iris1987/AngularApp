using BaseEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CategoryViewModel
    {

        public CategoryViewModel()
        {
            Subcategory = new HashSet<SubcategoryViewModel>();
        }

        public int IdCategory { get; set; }
        public string Categoryname { get; set; }

        public ICollection<SubcategoryViewModel> Subcategory { get; set; }

        //public static implicit operator CategoryViewModel(Category cat)
        //{
        //    return new CategoryViewModel
        //    {
        //        IdCategory = cat.IdCategory,
        //        Categoryname = cat.Categoryname//,

        //       // Subcategory = cat.Subcategory

        //    };
        //}
        //public static implicit operator Category(CategoryViewModel cat)
        //{
        //    return new Category
        //    {
        //        IdCategory = cat.IdCategory,
        //        Categoryname = cat.Categoryname//,

        //       // Subcategory = cat.Subcategory

        //    };
        //}
    }
}
