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
    }
}
