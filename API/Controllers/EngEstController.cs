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
    [Route("api/EngEst")]
    public class EngEstController:Controller
    {
        private readonly IMapper mapper;
        
        private readonly IGenericTranslate<TranslationEngEst> translation;
        private readonly IGenericService<LangEnglish> langEnglish;
        private readonly IGenericService<LangEstonian> langEstonian;
        private readonly IGenericService<PartOfSpeech> part;
        private readonly IGenericService<Subcategory> sub;
        private readonly IGenericService<Category> cat;
        public EngEstController(IGenericTranslate<TranslationEngEst> tr, IMapper mapper,
            IGenericService<LangEnglish> langEnglish,
            IGenericService<LangEstonian> langEstonian,
             IGenericService<PartOfSpeech> part,
             IGenericService<Subcategory> sub,
             IGenericService<Category> cat)
        {
            this.mapper = mapper;
            this.translation = tr;
            this.langEnglish = langEnglish;
            this.langEstonian = langEstonian;
            this.part = part;
            this.sub = sub;
            this.cat = cat;
        }
     
        // GET: EngEst
        // https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/adding-search
        [HttpGet]
        public ActionResult Index(string search, int category, int subcategory)
        {
            List<EngEstViewModel> model = new List<EngEstViewModel>();
            IEnumerable<TranslationEngEst> found;

            var wordEng = langEnglish.GetAll().ToList();
            var wordEst = langEstonian.GetAll().ToList();
            var parts = part.GetAll().ToList();
            var cats = cat.GetAll();
            var subs = sub.GetAll();
            
            //ViewBag.WordEng = wordEng;
            //ViewBag.WordEst = wordEst;
            //ViewBag.Parts = parts;
            //ViewBag.Cats = cats;
            //ViewBag.Subs = subs;

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
                var stuff = mapper.Map<TranslationEngEst, EngEstViewModel>(translation.GetByID(x.IdTranslation));
                model.Add(stuff);
            });

            //return View(model);
            return Json(model);
        }

        [HttpGet]
        public JsonResult GetByCategory(string search, int category)
        {
            List<EngEstViewModel> model = new List<EngEstViewModel>();
            IEnumerable<TranslationEngEst> found;

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
                var stuff = mapper.Map<TranslationEngEst, EngEstViewModel>(translation.GetByID(x.IdTranslation));
                model.Add(stuff);
            });
            //return View(model);
            return Json(model);
        }
        [HttpGet]
        public JsonResult GetBySubcategory(string search, int subcategory)
        {
            List<EngEstViewModel> model = new List<EngEstViewModel>();
            IEnumerable<TranslationEngEst> found;

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
                var stuff = mapper.Map<TranslationEngEst, EngEstViewModel>(translation.GetByID(x.IdTranslation));
                model.Add(stuff);
            });
            //return View(model);
            return Json(model);
        }
    }
}