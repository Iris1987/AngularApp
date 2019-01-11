using BaseEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class EngEstViewModel
    {
        public int IdTranslation { get; set; }
        public int IdWordEng { get; set; }
        public int IdWordEst { get; set; }
        public int? IdCategory { get; set; }
        public int? IdPart { get; set; }
        public string Example { get; set; }

        public Subcategory IdCategoryNavigation { get; set; }
        public PartOfSpeech IdPartNavigation { get; set; }
        public LangEnglish IdWordEngNavigation { get; set; }
        public LangEstonian IdWordEstNavigation { get; set; }


        //public static implicit operator EngEstViewModel(TranslationEngEst engest)
        //{
        //    return new EngEstViewModel
        //    {
        //        IdTranslation = engest.IdTranslation,
        //        IdWordEng = engest.IdWordEng,
        //        IdWordEst = engest.IdWordEst,
        //        IdCategory = engest.IdCategory,
        //        IdPart = engest.IdPart,
        //        Example = engest.Example,

        //        IdCategoryNavigation = engest.IdCategoryNavigation,
        //        IdPartNavigation = engest.IdPartNavigation,
        //        IdWordEngNavigation = engest.IdWordEngNavigation,
        //        IdWordEstNavigation = engest.IdWordEstNavigation
                
                
        //    };
        //}

        //public static implicit operator TranslationEngEst(EngEstViewModel vm)
        //{
        //    return new TranslationEngEst
        //    {
        //        IdTranslation = vm.IdTranslation,
        //        IdWordEng = vm.IdWordEng,
        //        IdWordEst = vm.IdWordEst,
        //        IdCategory = vm.IdCategory,
        //        IdPart = vm.IdPart,
        //        Example = vm.Example,

        //        IdCategoryNavigation = vm.IdCategoryNavigation,
        //        IdPartNavigation = vm.IdPartNavigation,
        //        IdWordEngNavigation = vm.IdWordEngNavigation,
        //        IdWordEstNavigation = vm.IdWordEstNavigation

        //    };
        //}
    }
}
