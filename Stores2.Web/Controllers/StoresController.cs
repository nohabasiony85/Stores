using Stores.BLL;
using Stores.BLL.DTOs;
using System.Web.Mvc;

namespace Stores2.Web.Controllers
{
    public class StoresController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public JsonResult GetStores()
        {
            var model = StoreLogic.GetAllStores();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Create(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                StoreLogic.CreateNewStore(model);
                return Json(new { IsSucceeded = true });
            }
            return Json(new { IsSucceeded = false });
        }
        
        public JsonResult GetbyId(int id)
        {
            var model= StoreLogic.GetStoreById(id);
            return Json(model,JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Edit(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                StoreLogic.EditStore(model);
                return Json(new { IsSucceeded = true });
            }
            return Json(new { IsSucceeded = false });

        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                StoreLogic.DeleteStore(id);
                return Json(new { IsSucceeded = true });
            }
            catch
            {
                return Json(new { IsSucceeded = false });
            }
        }
    }
}
