using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BaseEntities.Models;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using Services.Interfaces;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/EngRus")]
    public class EngRusController : Controller
    {
        
        private readonly IMapper mapper;

        private readonly IGenericTranslate<TranslationEngRus> translation;
        private readonly IGenericService<LangEnglish> langEnglish;
        private readonly IGenericService<LangRussian> langRussian;
        private readonly IGenericService<PartOfSpeech> part;
        private readonly IGenericService<Subcategory> sub;
        private readonly IGenericService<Category> cat;
        public EngRusController(IMapper mapper,
            IGenericService<LangEnglish> langEnglish,
            IGenericService<LangRussian> langRussian,
             IGenericService<PartOfSpeech> part,
             IGenericService<Subcategory> sub,
             IGenericService<Category> cat,
             IGenericTranslate<TranslationEngRus> translation)
        {
            this.mapper = mapper;
            this.langEnglish = langEnglish;
            this.langRussian = langRussian;
            this.part = part;
            this.sub = sub;
            this.cat = cat;
            this.translation = translation;
        }
        
        [HttpGet]
        public JsonResult Index(string search, int category, int subcategory)
        {
            List<EngRusViewModel> model = new List<EngRusViewModel>();
            IEnumerable<TranslationEngRus> found;


            if (!String.IsNullOrEmpty(search))
            {
                found = translation.Find(search);
            }
            else if (category!=0)
            {
                found = translation.GetByCategory(category);
            }
            else if (subcategory!=0)
            {
                found = translation.GetBySubcategory(subcategory);
            }
            else
            {
                found = translation.GetAll().ToList().OrderBy(x => x.IdWordEngNavigation.Word);
            }
            found.ToList().ForEach(x =>
            {
                var stuff = mapper.Map<TranslationEngRus, EngRusViewModel>(translation.GetByID(x.IdTranslation));
                model.Add(stuff);
            });

            //return View(model);
            return Json(model);
        }//
        [HttpGet]
        public JsonResult GetByCategory(string search, int category)
        {
            List<EngRusViewModel> model = new List<EngRusViewModel>();
            IEnumerable<TranslationEngRus> found;

            if (!String.IsNullOrEmpty(search) && category != 0)
            {
                found = translation.FindByCategory(category, search);
            }
            //else if (category != 0)
            //{
            //    found = translation.GetByCategory(category);
            //}
            else
            {
                found = translation.GetAll().ToList().OrderBy(x => x.IdWordEngNavigation.Word);
            }
            found.ToList().ForEach(x =>
            {
                var stuff = mapper.Map<TranslationEngRus, EngRusViewModel>(translation.GetByID(x.IdTranslation));
                model.Add(stuff);
            });
            //return View(model);
            return Json(model);
        }
        [HttpGet]
        public JsonResult GetBySubcategory(string search, int subcategory)
        {
            List<EngRusViewModel> model = new List<EngRusViewModel>();
            IEnumerable<TranslationEngRus> found;

            if (!String.IsNullOrEmpty(search) && subcategory != 0)
            {
                found = translation.FindBySubcategory(subcategory, search);
            }
            //else if (subcategory != 0)
            //{
            //    found = translation.GetBySubcategory(subcategory);
            //}
            else
            {
                found = translation.GetAll().ToList().OrderBy(x => x.IdWordEngNavigation.Word);
            }
            found.ToList().ForEach(x =>
            {
                var stuff = mapper.Map<TranslationEngRus, EngRusViewModel>(translation.GetByID(x.IdTranslation));
                model.Add(stuff);
            });
            //return View(model);
            return Json(model);
        }
    }
}