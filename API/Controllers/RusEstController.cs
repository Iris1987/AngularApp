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
    [Route("api/RusEst")]
    public class RusEstController : Controller
    {
        private readonly IMapper mapper;

        private readonly IGenericTranslate<TranslationRusEst> translation;
        private readonly IGenericService<LangEstonian> langEstonian;
        private readonly IGenericService<LangRussian> langRussian;
        private readonly IGenericService<PartOfSpeech> part;
        private readonly IGenericService<Subcategory> sub;
        private readonly IGenericService<Category> cat;
        public RusEstController(IMapper mapper,
            IGenericService<LangEstonian> langEstonian,
            IGenericService<LangRussian> langRussian,
             IGenericService<PartOfSpeech> part,
             IGenericService<Subcategory> sub,
             IGenericService<Category> cat,
             IGenericTranslate<TranslationRusEst> translation)
        {
            this.mapper = mapper;
            this.langEstonian = langEstonian;
            this.langRussian = langRussian;
            this.part = part;
            this.sub = sub;
            this.cat = cat;
            this.translation = translation;
        }
        [HttpGet]
        [Route("{search}")]
        public ActionResult Search(string search)
        {
            return Json(translation.Find(search));
        }

        [HttpGet]
        [Route("Cat/{category}/{search}")]
        public ActionResult GetByCat(string search, int category)
        {
            return Json(translation.FindByCategory(category, search));
        }
        [HttpGet]
        [Route("Subcat/{subcategory}/{search}")]
        public ActionResult GetBySubcat(string search, int subcategory)
        {
            return Json(translation.FindBySubcategory(subcategory, search));
        }
        [HttpGet]
        [Route("Cat/{category}/Subcat/{subcategory}/{search}")]
        public ActionResult GetByCatSubcat(string search, int category, int subcategory)
        {
            return Json(translation.FindByCatSubcat(category, subcategory, search));
        }
        //    #region
        //    [HttpGet]          
        //    public JsonResult Index(string search, int category, int subcategory)
        //    {
        //        List<RusEstViewModel> model = new List<RusEstViewModel>();
        //        IEnumerable<TranslationRusEst> found;

        //        if (!String.IsNullOrEmpty(search))
        //        {
        //            found = translation.Find(search);
        //        }
        //       else if (category != 0)
        //        {
        //            found = translation.GetByCategory(category);
        //        }
        //        else if (subcategory != 0)
        //        {
        //            found = translation.GetBySubcategory(subcategory);
        //        }
        //        else
        //        {
        //            found = translation.GetAll().ToList().OrderBy(x => x.IdWordRusNavigation.Word);
        //        }
        //        found.ToList().ForEach(x =>
        //        {
        //            var stuff = mapper.Map<TranslationRusEst, RusEstViewModel>(translation.GetByID(x.IdTranslation));
        //            model.Add(stuff);
        //        });
        //        //return View(model);
        //        return Json(model);
        //    }
        //    [HttpGet]
        //    public JsonResult GetByCategory(string search, int category)
        //    {
        //        List<RusEstViewModel> model = new List<RusEstViewModel>();
        //        IEnumerable<TranslationRusEst> found;

        //        if (!String.IsNullOrEmpty(search)&&category!=0)
        //        {
        //            found = translation.FindByCategory(category, search);
        //        }
        //        //else if (category != 0)
        //        //{
        //        //    found = translation.GetByCategory(category);
        //        //}
        //        else
        //        {
        //            found = translation.GetAll().ToList().OrderBy(x => x.IdWordRusNavigation.Word);
        //        }
        //        found.ToList().ForEach(x =>
        //        {
        //            var stuff = mapper.Map<TranslationRusEst, RusEstViewModel>(translation.GetByID(x.IdTranslation));
        //            model.Add(stuff);
        //        });
        //        //return View(model);
        //        return Json(model);
        //    }
        //    [HttpGet]
        //    public JsonResult GetBySubcategory(string search, int subcategory)
        //    {
        //        List<RusEstViewModel> model = new List<RusEstViewModel>();
        //        IEnumerable<TranslationRusEst> found;

        //        if (!String.IsNullOrEmpty(search)&&subcategory!=0)
        //        {
        //            found = translation.FindBySubcategory(subcategory, search);
        //        }
        //        //else if (subcategory != 0)
        //        //{
        //        //    found = translation.GetBySubcategory(subcategory);
        //        //}
        //        else
        //        {
        //            found = translation.GetAll().ToList().OrderBy(x => x.IdWordRusNavigation.Word);
        //        }
        //        found.ToList().ForEach(x =>
        //        {
        //            var stuff = mapper.Map<TranslationRusEst, RusEstViewModel>(translation.GetByID(x.IdTranslation));
        //            model.Add(stuff);
        //        });
        //        //return View(model);
        //        return Json(model);
        //    }
        //    #endregion

    }
}