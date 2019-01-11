using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseEntities.Models
{
    public partial class LangEnglish
    {
        public LangEnglish()
        {
            TranslationEngEst = new HashSet<TranslationEngEst>();
            TranslationEngRus = new HashSet<TranslationEngRus>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWord { get; set; }
        public string Word { get; set; }

        public ICollection<TranslationEngEst> TranslationEngEst { get; set; }
        public ICollection<TranslationEngRus> TranslationEngRus { get; set; }
    }
}
