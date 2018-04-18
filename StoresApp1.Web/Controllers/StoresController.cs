using Stores.BLL;
using Stores.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoresApp1.Web.Controllers
{
    public class StoresController : Controller
    {
        // GET: Stores
        public ActionResult Index()
        {
            var model = StoreLogic.GetAllStores();
            return View(model);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        public ActionResult Create(StoreViewModel model)
        {
            StoreLogic.CreateNewStore(model);

            return RedirectToAction("Index");

        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int id)
        {
            var model = StoreLogic.GetStoreById(id);
            return View(model);
        }

        // POST: Stores/Edit/5
        [HttpPost]
        public ActionResult Edit(StoreViewModel model)
        {
             StoreLogic.EditStore(model);
                return RedirectToAction("Index");
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int id)
        {
            var model = StoreLogic.GetStoreById(id);
            return View(model);
        }

        // POST: Stores/Delete/5
        [HttpPost]
        public ActionResult Delete(StoreViewModel model)
        {
            StoreLogic.DeleteStore(model.Id);
                return RedirectToAction("Index");
        }
    }
}
