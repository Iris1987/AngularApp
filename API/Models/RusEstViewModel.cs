using BaseEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class RusEstViewModel
    {
        public int IdTranslation { get; set; }
        public int IdWordRus { get; set; }
        public int IdWordEst { get; set; }
        public int? IdCategory { get; set; }
        public int? IdPart { get; set; }
        public string Example { get; set; }

        public Subcategory IdCategoryNavigation { get; set; }
        public PartOfSpeech IdPartNavigation { get; set; }
        public LangEstonian IdWordEstNavigation { get; set; }
        public LangRussian IdWordRusNavigation { get; set; }


        //public static implicit operator RusEstViewModel(TranslationRusEst item)
        //{
        //    return new RusEstViewModel
        //    {
        //        IdTranslation = item.IdTranslation,
        //        IdWordRus = item.IdWordRus,
        //        IdWordEst = item.IdWordEst,
        //        IdCategory = item.IdCategory,
        //        IdPart = item.IdPart,
        //        Example = item.Example,

        //        IdCategoryNavigation = item.IdCategoryNavigation,
        //        IdPartNavigation = item.IdPartNavigation,
        //        IdWordEstNavigation = item.IdWordEstNavigation,
        //        IdWordRusNavigation = item.IdWordRusNavigation

        //    };
        //}

        //public static implicit operator TranslationRusEst(RusEstViewModel item)
        //{
        //    return new TranslationRusEst
        //    {
        //        IdTranslation = item.IdTranslation,
        //        IdWordRus = item.IdWordRus,
        //        IdWordEst = item.IdWordEst,
        //        IdCategory = item.IdCategory,
        //        IdPart = item.IdPart,
        //        Example = item.Example,

        //        IdCategoryNavigation = item.IdCategoryNavigation,
        //        IdPartNavigation = item.IdPartNavigation,
        //        IdWordEstNavigation = item.IdWordEstNavigation,
        //        IdWordRusNavigation = item.IdWordRusNavigation

        //    };
        //}
    }
}
