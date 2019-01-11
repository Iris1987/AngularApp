using System;
using BaseEntities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Repos
{
    public partial class MyContext : DbContext
    {
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<LangEnglish> LangEnglishs { get; set; }
        public virtual DbSet<LangEstonian> LangEstonians { get; set; }
        public virtual DbSet<LangRussian> LangRussians { get; set; }
        public virtual DbSet<PartOfSpeech> PartOfSpeechs { get; set; }
        public virtual DbSet<Subcategory> Subcategorys { get; set; }
        public virtual DbSet<TranslationEngEst> TranslationEngEsts { get; set; }
        public virtual DbSet<TranslationEngRus> TranslationEngRuss { get; set; }
        public virtual DbSet<TranslationRusEst> TranslationRusEsts { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Data Source=mail.vk.edu.ee;Initial Catalog=db_Koroljova;Persist Security Info=True;User ID=t143447;Password=t143447");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory);

                entity.ToTable("Category", "dict");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnName("categoryname")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LangEnglish>(entity =>
            {
                entity.HasKey(e => e.IdWord);

                entity.ToTable("LangEnglish", "dict");

                entity.Property(e => e.IdWord).HasColumnName("id_word");

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasColumnName("word")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LangEstonian>(entity =>
            {
                entity.HasKey(e => e.IdWord);

                entity.ToTable("LangEstonian", "dict");

                entity.Property(e => e.IdWord).HasColumnName("id_word");

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasColumnName("word")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<LangRussian>(entity =>
            {
                entity.HasKey(e => e.IdWord);

                entity.ToTable("LangRussian", "dict");

                entity.Property(e => e.IdWord).HasColumnName("id_word");

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasColumnName("word")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<PartOfSpeech>(entity =>
            {
                entity.HasKey(e => e.IdPart);

                entity.ToTable("PartOfSpeech", "dict");

                entity.Property(e => e.IdPart).HasColumnName("id_part");

                entity.Property(e => e.Partname)
                    .IsRequired()
                    .HasColumnName("partname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.HasKey(e => e.IdSubcategory);

                entity.ToTable("Subcategory", "dict");

                entity.Property(e => e.IdSubcategory).HasColumnName("id_subcategory");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Subcategoryname)
                    .IsRequired()
                    .HasColumnName("subcategoryname")
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_category_subcategory");
            });

            modelBuilder.Entity<TranslationEngEst>(entity =>
            {
                entity.HasKey(e => e.IdTranslation);

                entity.ToTable("TranslationEngEst", "dict");

                entity.Property(e => e.IdTranslation).HasColumnName("id_translation");

                entity.Property(e => e.Example)
                    .HasColumnName("example")
                    .HasColumnType("ntext");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.IdPart).HasColumnName("id_part");

                entity.Property(e => e.IdWordEng).HasColumnName("id_word_eng");

                entity.Property(e => e.IdWordEst).HasColumnName("id_word_est");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.TranslationEngEst)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("fk_translation_eng_esCategory");

                entity.HasOne(d => d.IdPartNavigation)
                    .WithMany(p => p.TranslationEngEst)
                    .HasForeignKey(d => d.IdPart)
                    .HasConstraintName("fk_translation_eng_est_part");

                entity.HasOne(d => d.IdWordEngNavigation)
                    .WithMany(p => p.TranslationEngEst)
                    .HasForeignKey(d => d.IdWordEng)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_translation_eng_est_engword");

                entity.HasOne(d => d.IdWordEstNavigation)
                    .WithMany(p => p.TranslationEngEst)
                    .HasForeignKey(d => d.IdWordEst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_translation_eng_est_estword");
            });

            modelBuilder.Entity<TranslationEngRus>(entity =>
            {
                entity.HasKey(e => e.IdTranslation);

                entity.ToTable("TranslationEngRus", "dict");

                entity.Property(e => e.IdTranslation).HasColumnName("id_translation");

                entity.Property(e => e.Example)
                    .HasColumnName("example")
                    .HasColumnType("ntext");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.IdPart).HasColumnName("id_part");

                entity.Property(e => e.IdWordEng).HasColumnName("id_word_eng");

                entity.Property(e => e.IdWordRus).HasColumnName("id_word_rus");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.TranslationEngRus)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("fk_translation_eng_rus_category");

                entity.HasOne(d => d.IdPartNavigation)
                    .WithMany(p => p.TranslationEngRus)
                    .HasForeignKey(d => d.IdPart)
                    .HasConstraintName("fk_translation_eng_rus_part");

                entity.HasOne(d => d.IdWordEngNavigation)
                    .WithMany(p => p.TranslationEngRus)
                    .HasForeignKey(d => d.IdWordEng)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_translation_eng_rus_engword");

                entity.HasOne(d => d.IdWordRusNavigation)
                    .WithMany(p => p.TranslationEngRus)
                    .HasForeignKey(d => d.IdWordRus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_translation_eng_rus_rusword");
            });

            modelBuilder.Entity<TranslationRusEst>(entity =>
            {
                entity.HasKey(e => e.IdTranslation);

                entity.ToTable("TranslationRusEst", "dict");

                entity.Property(e => e.IdTranslation).HasColumnName("id_translation");

                entity.Property(e => e.Example)
                    .HasColumnName("example")
                    .HasColumnType("ntext");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.IdPart).HasColumnName("id_part");

                entity.Property(e => e.IdWordEst).HasColumnName("id_word_est");

                entity.Property(e => e.IdWordRus).HasColumnName("id_word_rus");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.TranslationRusEst)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("fk_translation_rus_esCategory");

                entity.HasOne(d => d.IdPartNavigation)
                    .WithMany(p => p.TranslationRusEst)
                    .HasForeignKey(d => d.IdPart)
                    .HasConstraintName("fk_translation_rus_est_part");

                entity.HasOne(d => d.IdWordEstNavigation)
                    .WithMany(p => p.TranslationRusEst)
                    .HasForeignKey(d => d.IdWordEst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_translation_rus_est_estword");

                entity.HasOne(d => d.IdWordRusNavigation)
                    .WithMany(p => p.TranslationRusEst)
                    .HasForeignKey(d => d.IdWordRus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_translation_rus_est_rusword");
            });
        }
    }
}
