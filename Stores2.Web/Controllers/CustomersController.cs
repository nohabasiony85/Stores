using Stores.BLL;
using Stores.BLL.DTOs;
using System.Web.Mvc;

namespace Stores2.Web.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public JsonResult GetCustomers()
        {
            var model = CustomerLogic.GetAllCustomers();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerLogic.CreateNewCustomer(model);
                return Json(new { IsSucceeded = true });
            }
            return Json(new { IsSucceeded = false });
        }
        
        public JsonResult GetbyId(int id)
        {
            var model= CustomerLogic.GetCustomerById(id);
            return Json(model,JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult Edit(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerLogic.EditCustomer(model);
                return Json(new { IsSucceeded = true });
            }
            return Json(new { IsSucceeded = false });

        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                CustomerLogic.DeleteCustomer(id);
                return Json(new { IsSucceeded = true });
            }
            catch 
            {
                return Json(new { IsSucceeded = false });
            }
        }
    }
}
