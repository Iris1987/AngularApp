using BaseEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class RusViewModel
    {
        

        public int IdWord { get; set; }
        public string Word { get; set; }

        public ICollection<TranslationEngRus> TranslationEngRus { get; set; }
        public ICollection<TranslationRusEst> TranslationRusEst { get; set; }

        //public static implicit operator RusViewModel(LangRussian item)
        //{
        //    return new RusViewModel
        //    {
        //        IdWord = item.IdWord,
        //        Word = item.Word

        //    };
        //}
        //public static implicit operator LangRussian(RusViewModel item)
        //{
        //    return new LangRussian
        //    {
        //        IdWord = item.IdWord,
        //        Word = item.Word

        //    };
        //}
    }
}
