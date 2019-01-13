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
        public EngEstController(
            IGenericTranslate<TranslationEngEst> tr,
            IMapper mapper,
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
    }
}