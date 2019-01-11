using BaseEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class EngViewModel
    {
        

        public int IdWord { get; set; }
        public string Word { get; set; }

        public ICollection<TranslationEngEst> TranslationEngEst { get; set; }
        public ICollection<TranslationEngRus> TranslationEngRus { get; set; }


        //public static implicit operator EngViewModel(LangEnglish item)
        //{
        //    return new EngViewModel
        //    {
        //        IdWord = item.IdWord,
        //        Word = item.Word

        //    };
        //}

        //public static implicit operator LangEnglish(EngViewModel item)
        //{
        //    return new LangEnglish
        //    {
        //        IdWord = item.IdWord,
        //        Word = item.Word

        //    };
        //}
    }
}
