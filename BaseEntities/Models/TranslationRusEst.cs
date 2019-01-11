using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseEntities.Models
{
    public partial class TranslationRusEst
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    }
}
