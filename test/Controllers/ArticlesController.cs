using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Models;
using test.Models;
using DataAccessLayer.Services;
using test.Models.Mappers;
using test.Auth;
using DataAccessLayer.Interfaces;

namespace test.Controllers
{
    public class ArticlesController : Controller
    {
        readonly IArticleService _articleService;
        readonly IStoreService _storeService;

        public ArticlesController(ArticleService articleService, StoreService storeService)
        {
            _articleService = articleService;
            _storeService = storeService;
        }

        // GET: Articles        
        public ActionResult Index(int storeId = -1)
        {
            List<SelectListItem> storesSelectItems;
            List<ArticleVM> model;

            var stores = _storeService.GetAll();
            if (stores.Count == 0)
            {
                storesSelectItems = new List<SelectListItem>();
            }
            else
            {
                storesSelectItems = stores.Select(x =>
                        new SelectListItem
                        {
                            Value = x.ID.ToString(),
                            Text = x.Name
                        }).ToList();
                if (storeId == -1)
                { storeId = stores.First().ID; }
            }
            ViewBag.Stores = storesSelectItems;

            var articles = _articleService.GetByStoreId(storeId);
            if (articles == null)
            {
                model = new List<ArticleVM>();
            }
            else
            {
                model = articles.Select(x => ArticleMappers.MapToVM(x)).ToList();
            }
            return View(model);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Article article = _articleService.GetById((int)id);

            if (article == null)
            {
                return HttpNotFound();
            }
            var model = ArticleMappers.MapToVM(article);
            return View(model);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.Stores = new StoreService().GetAll().Select(x =>
                        new SelectListItem
                        {
                            Value = x.ID.ToString(),
                            Text = x.Name
                        }).ToList();
            return View();
        }

        // POST: Articles/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Price,Total_in_shelf,Total_in_vault,StoreId")] AddEditArticleVM article)
        {
            if (ModelState.IsValid)
            {
                var articleToAdd = ArticleMappers.MapToArticle(article);
                _articleService.Add(articleToAdd);                
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = _articleService.GetById((int)id);
            
            if (article == null)
            {
                return HttpNotFound();
            }
            var articleVM = ArticleMappers.MapToAddEditVM(article);
            
            ViewBag.Stores = new StoreService().GetAll().Select(x =>
                        new SelectListItem
                        {
                            Value = x.ID.ToString(),
                            Text = x.Name
                        }).ToList();
            return View(articleVM);
        }
                        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,Total_in_shelf,Total_in_vault,StoreId")] AddEditArticleVM article)
        {
            if (ModelState.IsValid)
            {                
                var articleToEdit = ArticleMappers.MapToArticle(article);
                _articleService.Edit(articleToEdit);                
                return RedirectToAction("Index");
            }
            return View(article);
        }
                
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = _articleService.GetById((int)id);
            if (article == null)
            {
                return HttpNotFound();
            }

            return View(ArticleMappers.MapToVM(article));
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _articleService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
