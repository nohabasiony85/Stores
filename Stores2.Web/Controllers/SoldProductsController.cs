using Stores.BLL;
using Stores.BLL.DTOs;
using System.Web.Mvc;

namespace Stores2.Web.Controllers
{
    public class SoldProductsController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public JsonResult GetSoldProducts()
        {
            var model = SoldProductLogic.GetAllSoldProducts();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Create(SoldProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                SoldProductLogic.CreateNewSoldProduct(model);
                return Json(new { IsSucceeded = true });
            }
            return Json(new { IsSucceeded = false });
        }
        
        public JsonResult GetbyId(int id)
        {
            var model= SoldProductLogic.GetSoldProductById(id);
            return Json(model,JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Edit(SoldProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                SoldProductLogic.EditSoldProduct(model);
                return Json(new { IsSucceeded = true });
            }
            return Json(new { IsSucceeded = false });

        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                SoldProductLogic.DeleteSoldProduct(id);
                return Json(new { IsSucceeded = true });
            }
            catch
            {
                return Json(new { IsSucceeded = false });
            }
        }
    }
}
