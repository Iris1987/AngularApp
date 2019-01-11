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
            CreateMap<CategoryViewModel, Category>().ForMember(des => des.Categoryname, x => x.MapFrom(src => src.Categoryname))
                .ForMember(des => des.IdCategory, x => x.MapFrom(src => src.IdCategory))
                .ForMember(des => des.Subcategory, x => x.MapFrom(src => src.Subcategory));
            CreateMap<Category, CategoryViewModel>().ForMember(des => des.Categoryname, x => x.MapFrom(src => src.Categoryname))
                .ForMember(des => des.IdCategory, x => x.MapFrom(src => src.IdCategory))
                .ForMember(des => des.Subcategory, x => x.MapFrom(src => src.Subcategory)); ;

            CreateMap<EngEstViewModel, TranslationEngEst>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
                .ForMember(des => des.IdWordEngNavigation, x => x.MapFrom(src => src.IdWordEngNavigation))
                .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
                .ForMember(des => des.IdWordEstNavigation, x => x.MapFrom(src => src.IdWordEstNavigation));
            CreateMap<TranslationEngEst, EngEstViewModel>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
                .ForMember(des => des.IdWordEngNavigation, x => x.MapFrom(src => src.IdWordEngNavigation))
                .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
                .ForMember(des => des.IdWordEstNavigation, x => x.MapFrom(src => src.IdWordEstNavigation));

            CreateMap<EngRusViewModel, TranslationEngRus>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
                .ForMember(des => des.IdWordEngNavigation, x => x.MapFrom(src => src.IdWordEngNavigation))
                .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
                .ForMember(des => des.IdWordRusNavigation, x => x.MapFrom(src => src.IdWordRusNavigation)); 
            CreateMap<TranslationEngRus, EngRusViewModel>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
                .ForMember(des => des.IdWordEngNavigation, x => x.MapFrom(src => src.IdWordEngNavigation))
                .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
                .ForMember(des => des.IdWordRusNavigation, x => x.MapFrom(src => src.IdWordRusNavigation)); 

            CreateMap<RusEstViewModel, TranslationRusEst>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
                .ForMember(des => des.IdWordEstNavigation, x => x.MapFrom(src => src.IdWordEstNavigation))
                .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
                .ForMember(des => des.IdWordRusNavigation, x => x.MapFrom(src => src.IdWordRusNavigation)); 
            CreateMap<TranslationRusEst, RusEstViewModel>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
                .ForMember(des => des.IdWordEstNavigation, x => x.MapFrom(src => src.IdWordEstNavigation))
                .ForMember(des => des.IdPartNavigation, x => x.MapFrom(src => src.IdPartNavigation))
                .ForMember(des => des.IdWordRusNavigation, x => x.MapFrom(src => src.IdWordRusNavigation)); 

            CreateMap<EngViewModel, LangEnglish>();
            CreateMap<LangEnglish, EngViewModel>();

            CreateMap<EstViewModel, LangEstonian>();
            CreateMap<LangEstonian, EstViewModel>();

            CreateMap<RusViewModel, LangRussian>();
            CreateMap<LangRussian, RusViewModel>();

            CreateMap<PartOfSpeechViewModel, PartOfSpeech>();
            CreateMap<PartOfSpeech, PartOfSpeechViewModel>();

           /* CreateMap<SubcategoryViewModel, Subcategory>();
            CreateMap<Subcategory, SubcategoryViewModel>();*/
            
              CreateMap<SubcategoryViewModel, Subcategory>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
                .ForMember(des => des.IdCategory, x => x.MapFrom(src => src.IdCategory))
                .ForMember(des => des.IdSubcategory, x => x.MapFrom(src => src.IdSubcategory))
                .ForMember(des => des.TranslationEngEst, x => x.MapFrom(src => src.TranslationEngEst))
                .ForMember(des => des.TranslationEngRus, x => x.MapFrom(src => src.TranslationEngRus))
                .ForMember(des => des.TranslationRusEst, x => x.MapFrom(src => src.TranslationRusEst))
                .ForMember(des => des.Subcategoryname, x => x.MapFrom(src => src.Subcategoryname));
            CreateMap<Subcategory, SubcategoryViewModel>().ForMember(des => des.IdCategoryNavigation, x => x.MapFrom(src => src.IdCategoryNavigation))
                .ForMember(des => des.IdCategory, x => x.MapFrom(src => src.IdCategory))
                .ForMember(des => des.IdSubcategory, x => x.MapFrom(src => src.IdSubcategory))
                .ForMember(des => des.TranslationEngEst, x => x.MapFrom(src => src.TranslationEngEst))
                .ForMember(des => des.TranslationEngRus, x => x.MapFrom(src => src.TranslationEngRus))
                .ForMember(des => des.TranslationRusEst, x => x.MapFrom(src => src.TranslationRusEst))
                .ForMember(des => des.Subcategoryname, x => x.MapFrom(src => src.Subcategoryname));

            //need to replace some arguments
            //var configEngEst = new MapperConfiguration(cfg => cfg.CreateMap<TranslEngEst, EngEstDTO>()
            //.ForMember(des => des.ID, x => x.MapFrom(src => src.IdTranslation))
            //.ForMember(des => des.PartOfSpeech, x => x.MapFrom(src => src.PartOfSpeech.Partname))
            //.ForMember(des => des.Subcategory, x => x.MapFrom(src => src.Subcategory.Subcategoryname))
            //.ForMember(des => des.Category, x => x.MapFrom(src => src.Subcategory.Category.Categoryname))
            //.ForMember(des => des.EngWord, x => x.MapFrom(src => src.EngWord.Word))
            //.ForMember(des => des.EstWord, x => x.MapFrom(src => src.EstWord.Word)));

            ////hz
            //var configEngEstViseVersa = new MapperConfiguration(cfg => cfg.CreateMap<EngEstDTO, TranslEngEst>()
            //.ForMember(des => des.IdTranslation, x => x.MapFrom(src => src.ID))
            //.ForMember(des => des.PartOfSpeech.Partname, x => x.MapFrom(src => src.PartOfSpeech))
            //.ForMember(des => des.Subcategory.Subcategoryname, x => x.MapFrom(src => src.Subcategory))
            //.ForMember(des => des.Subcategory.Category.Categoryname, x => x.MapFrom(src => src.Category))
            //.ForMember(des => des.EngWord.Word, x => x.MapFrom(src => src.EngWord))
            //.ForMember(des => des.EstWord.Word, x => x.MapFrom(src => src.EstWord)));

            //AutomapperConfiguration.Configure(); add method and then add this to the beginning of startup
        }
    }
}
