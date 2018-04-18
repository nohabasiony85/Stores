using Stores.BLL;
using Stores.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoresApp1.Web.Controllers
{
    public class SoldProductsController : Controller
    {

        // GET: SoldProducts
        public ActionResult Index()
        {
            var model = SoldProductLogic.GetAllSoldProducts();
            return View(model);
        }

        // GET: SoldProducts/Create
        public ActionResult Create()
        {
            var model = SoldProductLogic.GetAllInitialData();

            return View(model);
        }

        // POST: SoldProducts/Create
        [HttpPost]
        public ActionResult Create(SoldProductViewModel model)
        {
            SoldProductLogic.CreateNewSoldProduct(model);
                return RedirectToAction("Index");
            
        }
        
        // GET: SoldProducts/Edit/5
        public ActionResult Edit(int id)
        {
            var model = SoldProductLogic.GetSoldProductById(id);
            ViewBag.DropDownListData = SoldProductLogic.GetAllInitialData()?? new SoldProductViewModel();
            return View(model);
        }

        // POST: SoldProducts/Edit/5
        [HttpPost]
        public ActionResult Edit(SoldProductViewModel model)
        {
             SoldProductLogic.EditSoldProduct(model);
                return RedirectToAction("Index");
        }

        // GET: SoldProducts/Delete/5
        public ActionResult Delete(int id)
        {
            var model = SoldProductLogic.GetSoldProductById(id);
            return View(model);
        }

        // POST: SoldProducts/Delete/5
        [HttpPost]
        public ActionResult Delete(SoldProductViewModel model)
        {
            SoldProductLogic.DeleteSoldProduct(model.Id);
            return RedirectToAction("Index");
        }


    }
}
