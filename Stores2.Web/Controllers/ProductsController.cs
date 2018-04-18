using Stores.BLL;
using Stores.BLL.DTOs;
using System.Web.Mvc;

namespace Stores2.Web.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public JsonResult GetProducts()
        {
            var model = ProductLogic.GetAllProducts();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProductLogic.CreateNewProduct(model);
                return Json(new { IsSucceeded = true });
            }
            return Json(new { IsSucceeded = false });
        }
        
        public JsonResult GetbyId(int id)
        {
            var model= ProductLogic.GetProductById(id);
            return Json(model,JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProductLogic.EditProduct(model);
                return Json(new { IsSucceeded = true });
            }
            return Json(new { IsSucceeded = false });

        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                ProductLogic.DeleteProduct(id);
                return Json(new { IsSucceeded = true });
            }
            catch
            {
                return Json(new { IsSucceeded = false });
            }
        }
    }
}
