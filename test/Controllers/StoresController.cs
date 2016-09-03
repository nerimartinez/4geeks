using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
using test.Models.Mappers;
using test.Models;

namespace test.Controllers
{
    public class StoresController : Controller
    {        
        readonly IStoreService _storeService;

        public StoresController(StoreService storeService)
        {
            _storeService = storeService;
        }

        // GET: Stores
        public ActionResult Index()
        {
            var model = _storeService.GetAll().Select(x=> StoreMappers.MapToVM(x)).ToList();

            return View(model);
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Store store = _storeService.GetById((int)id);
            if (store == null)
            {
                return HttpNotFound();
            }
            var model = StoreMappers.MapToVM(store);
            return View(model);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address")] StoreVM store)
        {
            if (ModelState.IsValid)
            {
                _storeService.Add(StoreMappers.MapToModel(store));                
                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = _storeService.GetById((int)id);
            if (store == null)
            {
                return HttpNotFound();
            }
            var model = StoreMappers.MapToVM(store);
            return View(model);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address")] StoreVM store)
        {
            if (ModelState.IsValid)
            {
                _storeService.Edit(StoreMappers.MapToModel(store));
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = _storeService.GetById((int)id);
            if (store == null)
            {
                return HttpNotFound();
            }
            var model = StoreMappers.MapToVM(store);
            return View(model);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _storeService.Delete(id);
            return RedirectToAction("Index");
        }        
    }
}
