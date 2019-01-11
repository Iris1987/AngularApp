using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseEntities.Models
{
    public partial class LangEstonian
    {
        public LangEstonian()
        {
            TranslationEngEst = new HashSet<TranslationEngEst>();
            TranslationRusEst = new HashSet<TranslationRusEst>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWord { get; set; }
        public string Word { get; set; }

        public ICollection<TranslationEngEst> TranslationEngEst { get; set; }
        public ICollection<TranslationRusEst> TranslationRusEst { get; set; }
    }
}
