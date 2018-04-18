using Stores.BLL;
using Stores.BLL.DTOs;
using System.Web.Mvc;

namespace StoresApp1.Web.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Prodcuts
        public ActionResult Index()
        {
            var model = ProductLogic.GetAllProducts();

            return View(model);
        }

        // GET: Prodcuts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prodcuts/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            ProductLogic.CreateNewProduct(model);
                return RedirectToAction("Index");
        }

        // GET: Prodcuts/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ProductLogic.GetProductById(id);
            return View(model);
        }

        // POST: Prodcuts/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            ProductLogic.EditProduct(model);

                return RedirectToAction("Index");
        }

        // GET: Prodcuts/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ProductLogic.GetProductById(id);
            return View(model);
        }

        // POST: Prodcuts/Delete/5
        [HttpPost]
        public ActionResult Delete(ProductViewModel model)
        {
            
                ProductLogic.DeleteProduct(model.Id);
                return RedirectToAction("Index");
        }
    }
}
