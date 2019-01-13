using AutoMapper;
using BaseEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().PreserveReferences().ReverseMap();
            CreateMap<Subcategory, SubcategoryViewModel>().PreserveReferences().ReverseMap();
            CreateMap<TranslationEngRus, EngEstViewModel>().PreserveReferences().ReverseMap();
            CreateMap<TranslationEngRus, EngRusViewModel>().PreserveReferences().ReverseMap();
            CreateMap<TranslationRusEst, RusEstViewModel>().PreserveReferences().ReverseMap();
            CreateMap<PartOfSpeech, PartOfSpeechViewModel>().PreserveReferences().ReverseMap();

            //CreateMap<CategoryViewModel, Category>().ForMember(des => des.Categoryname, x => x.MapFrom(src => src.Categoryname))
            //    .ForMember(des => des.IdCategory, x => x.MapFrom(src => src.IdCategory))
            //    .ForMember(des => des.Subcategory, x => x.MapFrom(src => src.Subcategory));
            //CreateMap<Category, CategoryViewModel>().ForMember(des => des.Categoryname, x => x.MapFrom(src => src.Categoryname))
            //    .ForMember(des => des.IdCategory, x => x.MapFrom(src => src.IdCategory))
            //    .ForMember(des => des.Subcategory, x => x.MapFrom(src => src.Subcategory));
            ////CreateMap<Category, CategoryViewModel>().ReverseMap();
            ////CreateMap<CategoryViewModel, Category>();

            //CreateMap<EngEstViewModel, TranslationEngEst>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
            //    .ForMember(des => des.IdWordEngNavigation, x => x.MapFrom(src => src.IdWordEngNavigation))
            //    .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
            //    .ForMember(des => des.IdWordEstNavigation, x => x.MapFrom(src => src.IdWordEstNavigation));
            //CreateMap<TranslationEngEst, EngEstViewModel>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
            //    .ForMember(des => des.IdWordEngNavigation, x => x.MapFrom(src => src.IdWordEngNavigation))
            //    .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
            //    .ForMember(des => des.IdWordEstNavigation, x => x.MapFrom(src => src.IdWordEstNavigation));

            //CreateMap<EngRusViewModel, TranslationEngRus>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
            //    .ForMember(des => des.IdWordEngNavigation, x => x.MapFrom(src => src.IdWordEngNavigation))
            //    .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
            //    .ForMember(des => des.IdWordRusNavigation, x => x.MapFrom(src => src.IdWordRusNavigation));
            //CreateMap<TranslationEngRus, EngRusViewModel>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
            //    .ForMember(des => des.IdWordEngNavigation, x => x.MapFrom(src => src.IdWordEngNavigation))
            //    .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
            //    .ForMember(des => des.IdWordRusNavigation, x => x.MapFrom(src => src.IdWordRusNavigation));

            //CreateMap<RusEstViewModel, TranslationRusEst>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
            //    .ForMember(des => des.IdWordEstNavigation, x => x.MapFrom(src => src.IdWordEstNavigation))
            //    .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
            //    .ForMember(des => des.IdWordRusNavigation, x => x.MapFrom(src => src.IdWordRusNavigation));
            //CreateMap<TranslationRusEst, RusEstViewModel>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
            //    .ForMember(des => des.IdWordEstNavigation, x => x.MapFrom(src => src.IdWordEstNavigation))
            //    .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
            //    .ForMember(des => des.IdWordRusNavigation, x => x.MapFrom(src => src.IdWordRusNavigation));

            //CreateMap<EngViewModel, LangEnglish>();
            //CreateMap<LangEnglish, EngViewModel>();

            //CreateMap<EstViewModel, LangEstonian>();
            //CreateMap<LangEstonian, EstViewModel>();

            //CreateMap<RusViewModel, LangRussian>();
            //CreateMap<LangRussian, RusViewModel>();

            //CreateMap<PartOfSpeechViewModel, PartOfSpeech>();
            //CreateMap<PartOfSpeech, PartOfSpeechViewModel>();

            ///* CreateMap<SubcategoryViewModel, Subcategory>();
            // CreateMap<Subcategory, SubcategoryViewModel>();*/

            //CreateMap<SubcategoryViewModel, Subcategory>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
            //  .ForMember(des => des.IdCategory, x => x.MapFrom(src => src.IdCategory))
            //  .ForMember(des => des.IdSubcategory, x => x.MapFrom(src => src.IdSubcategory))
            //  .ForMember(des => des.TranslationEngEst, x => x.MapFrom(src => src.TranslationEngEst))
            //  .ForMember(des => des.TranslationEngRus, x => x.MapFrom(src => src.TranslationEngRus))
            //  .ForMember(des => des.TranslationRusEst, x => x.MapFrom(src => src.TranslationRusEst))
            //  .ForMember(des => des.Subcategoryname, x => x.MapFrom(src => src.Subcategoryname));
            //CreateMap<Subcategory, SubcategoryViewModel>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
            //    .ForMember(des => des.IdCategory, x => x.MapFrom(src => src.IdCategory))
            //    .ForMember(des => des.IdSubcategory, x => x.MapFrom(src => src.IdSubcategory))
            //    .ForMember(des => des.TranslationEngEst, x => x.MapFrom(src => src.TranslationEngEst))
            //    .ForMember(des => des.TranslationEngRus, x => x.MapFrom(src => src.TranslationEngRus))
            //    .ForMember(des => des.TranslationRusEst, x => x.MapFrom(src => src.TranslationRusEst))
            //    .ForMember(des => des.Subcategoryname, x => x.MapFrom(src => src.Subcategoryname));
        }
    }
}
