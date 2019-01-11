using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseEntities.Models
{
    public partial class LangRussian
    {
        public LangRussian()
        {
            TranslationEngRus = new HashSet<TranslationEngRus>();
            TranslationRusEst = new HashSet<TranslationRusEst>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWord { get; set; }
        public string Word { get; set; }

        public ICollection<TranslationEngRus> TranslationEngRus { get; set; }
        public ICollection<TranslationRusEst> TranslationRusEst { get; set; }
    }
}
