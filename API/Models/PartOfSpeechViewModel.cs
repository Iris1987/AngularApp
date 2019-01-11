using BaseEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PartOfSpeechViewModel
    {
        

        public int IdPart { get; set; }
        public string Partname { get; set; }

        public ICollection<TranslationEngEst> TranslationEngEst { get; set; }
        public ICollection<TranslationEngRus> TranslationEngRus { get; set; }
        public ICollection<TranslationRusEst> TranslationRusEst { get; set; }


        //public static implicit operator PartOfSpeechViewModel(PartOfSpeech item)
        //{
        //    return new PartOfSpeechViewModel
        //    {
        //        IdPart = item.IdPart,
        //        Partname = item.Partname

        //    };
        //}

        //public static implicit operator PartOfSpeech(PartOfSpeechViewModel item)
        //{
        //    return new PartOfSpeech
        //    {
        //        IdPart = item.IdPart,
        //        Partname = item.Partname

        //    };
        //}
    }
}
