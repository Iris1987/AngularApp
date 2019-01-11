using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseEntities.Models
{
    public class Translation1Map
    {
        public Translation1Map(EntityTypeBuilder<TranslationEngEst> entityBuilder)
        {
            //    entityBuilder.HasKey(t => t.IdTranslation);
            //    entityBuilder.Property(t => t.IdWordEng).IsRequired();
            //    entityBuilder.Property(t => t.IdWordEst).IsRequired();
            //    entityBuilder.Property(t => t.IdCategory).IsRequired();
            //    entityBuilder.Property(t => t.IdPart).IsRequired();
            //    entityBuilder.Property(t => t.Example).IsRequired();
            //    entityBuilder.HasOne(t => t.IdCategoryNavigation).WithOne(u => u.).HasForeignKey<Subcategory>(x => x.IdCategoryNavigation);
        }
    }
}
