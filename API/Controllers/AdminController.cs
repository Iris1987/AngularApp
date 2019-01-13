using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BaseEntities.Models;
using Microsoft.AspNetCore.Html;
using API.Models;
using Services;
using Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    // all updating and removing methods
    [Produces("application/json")]
    [Route("api/Admin")]
    //[Authorize]
    public class AdminController : Controller
    {
        private readonly IMapper mapper;

        private readonly IGenericTranslate<TranslationEngEst> translation;
        private readonly IGenericTranslate<TranslationEngRus> translationEngRus;
        private readonly IGenericTranslate<TranslationRusEst> translationRusEst;
        private readonly IGenericService<LangEnglish> langEnglish;
        private readonly IGenericService<LangEstonian> langEstonian;
        private readonly IGenericService<LangRussian> langRussian;
        private readonly IGenericService<PartOfSpeech> part;
        private readonly IGenericService<Category> cat;
        private readonly IGenericService<Subcategory> sub;

        public AdminController(IMapper mapper, IGenericTranslate<TranslationEngEst> translation, IGenericService<LangEnglish> langEnglish,
            IGenericService<LangEstonian> langEstonian,
            IGenericService<PartOfSpeech> part,
            IGenericService<Category> cat,
            IGenericService<Subcategory> sub,
            IGenericService<LangRussian> langRussian,
            IGenericTranslate<TranslationRusEst> translationRusEst,
            IGenericTranslate<TranslationEngRus> translationEngRus)
        {
            this.mapper = mapper;
            this.translation = translation;
            this.langEnglish = langEnglish;
            this.langEstonian = langEstonian;
            this.part = part;
            this.cat = cat;
            this.sub = sub;
            this.langRussian = langRussian;
            this.translationEngRus = translationEngRus;
            this.translationRusEst = translationRusEst;

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
        /// ENGEST
        /// 
        /// 
        [HttpPost]
        [Route("")]
        public ActionResult UpdateENGEST(EngEstViewModel ee)
        {

            translation.Update(mapper.Map<EngEstViewModel, TranslationEngEst>(ee));
           
            return Ok();
        }

        [HttpPost]
        [Route("")]
        public ActionResult DeleteENGEST(int id)
        {

            translation.Delete(id);

            return Ok();
        }
        [HttpPost]
        [Route("")]
        public ActionResult CreateENGEST(EngEstViewModel ee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    translation.Create(mapper.Map<EngEstViewModel, TranslationEngEst>(ee));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. ");

            }
            return Ok();
        }

        /// ENGRUS
        /// 
        /// 
        [HttpPost]
        [Route("")]
        public ActionResult UpdateENGRUS(EngRusViewModel ee)
        {

            translationEngRus.Update(mapper.Map<EngRusViewModel,TranslationEngRus>(ee));

            return Ok();
        }

        [HttpPost]
        [Route("")]
        public ActionResult DeleteENGRUS(int id)
        {

            translationEngRus.Delete(id);

            return Ok();
        }
        [HttpPost]
        [Route("")]
        public ActionResult CreateENGRUS(EngRusViewModel ee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    translationEngRus.Create(mapper.Map<EngRusViewModel, TranslationEngRus>(ee));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. ");

            }
            return Ok();
        }

        /// RUSEST
        /// 
        /// 
        [HttpPost]
        [Route("")]
        public ActionResult UpdateRUSEST(RusEstViewModel ee)
        {

            translationRusEst.Update(mapper.Map<RusEstViewModel, TranslationRusEst>(ee));

            return Ok();
        }

        [HttpPost]
        [Route("")]
        public ActionResult DeleteRUSEST(int id)
        {

            translationRusEst.Delete(id);

            return Ok();
        }
        [HttpPost]
        [Route("")]
        public ActionResult CreateRUSEST(RusEstViewModel ee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    translationRusEst.Create(mapper.Map<RusEstViewModel, TranslationRusEst>(ee));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. ");

            }
            return Ok();
        }

        /// CATEGORY
        /// 
        /// 
        [HttpPost]
        [Route("")]
        public ActionResult UpdateCATEGORY(CategoryViewModel ee)
        {

            cat.Update(mapper.Map<CategoryViewModel, Category>(ee));

            return Ok();
        }

        [HttpPost]
        [Route("")]
        public ActionResult DeleteCATEGORY(int id)
        {

            cat.Delete(id);

            return Ok();
        }
        [HttpPost]
        [Route("")]
        public ActionResult CreateCATEGORY(CategoryViewModel ee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    cat.Create(mapper.Map<CategoryViewModel, Category>(ee));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. ");

            }
            return Ok();
        }

        /// SUBCATEGORY
        /// 
        /// 
        [HttpPost]
        [Route("")]
        public ActionResult UpdateSUBCATEGORY(SubcategoryViewModel ee)
        {

            sub.Update(mapper.Map<SubcategoryViewModel, Subcategory>(ee));

            return Ok();
        }

        [HttpPost]
        [Route("")]
        public ActionResult DeleteSUBCATEGORY(int id)
        {

            sub.Delete(id);

            return Ok();
        }
        [HttpPost]
        [Route("")]
        public ActionResult CreateSUBCATEGORY(SubcategoryViewModel ee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    sub.Create(mapper.Map<SubcategoryViewModel, Subcategory>(ee));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes. ");

            }
            return Ok();
        }
        #region
        //    [HttpGet]
        //    public /*ActionResult*/ JsonResult Index(string search)
        //    {
        //        List<EngEstViewModel> model = new List<EngEstViewModel>();
        //        IEnumerable<TranslationEngEst> found;

        //        var wordEng = langEnglish.GetAll().ToList();
        //        var wordEst = langEstonian.GetAll().ToList();
        //        var parts = part.GetAll().ToList();
        //        var cats = cat.GetAll();
        //        var subs = sub.GetAll();
        //        var wordRus = langRussian.GetAll().ToList();

        //        //ViewBag.WordEng = wordEng;
        //        //ViewBag.WordEst = wordEst;
        //        //ViewBag.Parts = parts;
        //        //ViewBag.Cats = cats;
        //        //ViewBag.Subs = subs;
        //        //ViewBag.WordRus = wordRus;

        //        if (!String.IsNullOrEmpty(search))
        //        {
        //            found = translation.Find(search);
        //        }
        //        else
        //        {
        //            found = translation.GetAll().ToList().OrderBy(x => x.IdWordEngNavigation.Word);
        //        }
        //        found.ToList().ForEach(x =>
        //        {
        //            var stuff = mapper.Map<TranslationEngEst, EngEstViewModel>(translation.GetByID(x.IdTranslation));
        //            model.Add(stuff);
        //        });

        //        //return View(model);
        //        return Json(model);
        //    }

        //    // ------------------------------------------------------- ENG EST TRANSLATE
        //    // ------------------------------------------------------- ENG EST TRANSLATE
        //    // ------------------------------------------------------- ENG EST TRANSLATE

        //    public ActionResult CreateEngEst(EngEstViewModel model)
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                translation.Create(mapper.Map<EngEstViewModel, TranslationEngEst>(model));

        //                //TranslationEngEst trans = new TranslationEngEst();
        //                //translation.Create(trans);
        //                //return RedirectToAction(nameof(Index));
        //            }
        //        }
        //        catch
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. ");

        //        }
        //        return RedirectToAction("Index");
        //    }



        //    [HttpPost]
        //    public ActionResult UpdateEngEst(EngEstViewModel ee)
        //    {
        //        translation.Update(mapper.Map<EngEstViewModel, TranslationEngEst>(ee));
        //        return RedirectToAction("Index");
        //    }

        //    public ActionResult DeleteEngEst(int id)
        //    {
        //        translation.Delete(id);
        //        return RedirectToAction("Index");

        //    }

        //    // ------------------------------------------------------- ENG RUS TRANSLATE
        //    // ------------------------------------------------------- ENG RUS TRANSLATE
        //    // ------------------------------------------------------- ENG RUS TRANSLATE
        //    public JsonResult ManageEngRus(string search)
        //    {
        //        List<EngRusViewModel> model = new List<EngRusViewModel>();
        //        IEnumerable<TranslationEngRus> found;
        //        var wordEng = langEnglish.GetAll().ToList();
        //        var wordRus = langRussian.GetAll().ToList();
        //        var parts = part.GetAll().ToList();
        //        var cats = cat.GetAll();
        //        var subs = sub.GetAll();

        //        ViewBag.WordEng = wordEng;
        //        ViewBag.WordRus = wordRus;

        //        if (!String.IsNullOrEmpty(search))
        //        {
        //            found = translationEngRus.Find(search);
        //        }
        //        else
        //        {
        //            found = translationEngRus.GetAll().ToList().OrderBy(x => x.IdWordEng);
        //        }
        //          found.ToList().ForEach(x =>
        //          {
        //              var stuff = mapper.Map<TranslationEngRus, EngRusViewModel>(translationEngRus.GetByID(x.IdTranslation));
        //              model.Add(stuff);
        //          });

        //        //return View(model);
        //        return Json(model);
        //    }


        //    public ActionResult CreateEngRus(EngRusViewModel model)
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                translationEngRus.Create(mapper.Map<EngRusViewModel, TranslationEngRus>(model));
        //            }
        //        }
        //        catch
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. ");

        //        }
        //        return RedirectToAction("ManageEngRus");
        //    }

        //  /*  [HttpPost]
        //    public ActionResult UpdateEngRus(EngRusViewModel model)
        //    {
        //        translationEngRus.Update(mapper.Map<EngRusViewModel, TranslationEngRus>(model));

        //        return RedirectToAction("Index");
        //    }*/

        //    public ActionResult DeleteEngRus(int id)
        //    {
        //        translationEngRus.Delete(id);
        //        return RedirectToAction("ManageEngRus");

        //    }

        //    // ------------------------------------------------------- RUS EST TRANSLATE
        //    // ------------------------------------------------------- RUS EST TRANSLATE
        //    // ------------------------------------------------------- RUS EST TRANSLATE

        //    public ActionResult ManageRusEst(string search)
        //    {
        //        List<RusEstViewModel> model = new List<RusEstViewModel>();
        //        IEnumerable<TranslationRusEst> found;
        //        var wordEst = langEstonian.GetAll().ToList();
        //        var wordRus = langRussian.GetAll().ToList();
        //        var parts = part.GetAll().ToList();
        //        var cats = cat.GetAll();
        //        var subs = sub.GetAll();

        //        ViewBag.WordEst = wordEst;
        //        ViewBag.WordRus = wordRus;

        //        if (!String.IsNullOrEmpty(search))
        //        {
        //            found = translationRusEst.Find(search);
        //        }
        //        else
        //        {
        //            found = translationRusEst.GetAll().ToList().OrderBy(x => x.IdWordRus);
        //        }
        //        found.ToList().ForEach(x =>
        //        {
        //            var stuff = mapper.Map<TranslationRusEst, RusEstViewModel>(translationRusEst.GetByID(x.IdTranslation));
        //            model.Add(stuff);
        //        });

        //        return View(model);
        //    }


        //    public ActionResult CreateRusEst(RusEstViewModel model)
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                translationRusEst.Create(mapper.Map<RusEstViewModel, TranslationRusEst>(model));
        //            }
        //        }
        //        catch
        //        {
        //            ModelState.AddModelError("", "Unable to save changes. ");

        //        }
        //        return RedirectToAction("ManageRusEst");
        //    }

        //    public ActionResult DeleteRusEst(int id)
        //    {
        //        translationRusEst.Delete(id);
        //        return RedirectToAction("ManageRusEst");

        //    }

        //    // ------------------------------------------------------- CATEGORIES
        //    // ------------------------------------------------------- CATEGORIES
        //    // ------------------------------------------------------- CATEGORIES
        //    public /*ActionResult*/ JsonResult Categories(string search)
        //    {
        //        List<CategoryViewModel> model = new List<CategoryViewModel>();
        //        IEnumerable<Category> found;
        //        var cats = cat.GetAll();
        //        var subs = sub.GetAll();

        //        ViewBag.Cats = cats;
        //        ViewBag.Subs = subs;

        //        if (!String.IsNullOrEmpty(search))
        //        {
        //            found = cat.Find(search);
        //        }
        //        else
        //        {
        //            found = cat.GetAll().ToList().OrderBy(x => x.Categoryname);
        //        }
        //        /*  found.ToList().ForEach(x =>
        //          {
        //              //   var stuff = mapper.Map<Category, CategoryViewModel>(cat.GetByID(x.IdCategory));
        //              var stuff = new CategoryViewModel()
        //              {
        //                  stuff.IdCategory = x.IdCategory,
        //                  stuff.Subcategory = x.Subcategory,
        //                  stuff.Categoryname = x.Categoryname
        //              };
        //              model.Add(stuff);
        //          });*/

        //        foreach (var item in found)
        //        {
        //            var stuff = new CategoryViewModel()
        //            {
        //                Categoryname = item.Categoryname,
        //                IdCategory = item.IdCategory
        //            };
        //            model.Add(stuff);
        //        }

        //        return Json(model);
        //    }


        //    [HttpPost]
        //    public ActionResult CreateCategory(CategoryViewModel model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var stuff = new Category()
        //            {
        //                Categoryname = model.Categoryname
        //            };
        //            cat.Create(stuff);
        //        }

        //        return RedirectToAction("Categories");
        //}

        //public ActionResult DeleteCategory(int id)
        //{
        //    cat.Delete(id);
        //    return RedirectToAction("Categories");

        //}

        //    //---------------------------------------------------------- SUBCATEGORIES
        //    public ActionResult CreateSubcategory(SubcategoryViewModel model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var stuff = new Subcategory()
        //            {
        //                Subcategoryname = model.Subcategoryname,
        //                IdCategory = model.IdCategory

        //            };
        //            sub.Create(stuff);
        //        }

        //        return RedirectToAction("Categories");
        //    }

        //    public ActionResult DeleteSubcategory(int id)
        //    {
        //        sub.Delete(id);
        //        return RedirectToAction("Categories");

        //    }
        #endregion
    }
}