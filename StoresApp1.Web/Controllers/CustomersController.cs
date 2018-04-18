using Stores.BLL;
using Stores.BLL.DTOs;
using System.Web.Mvc;

namespace StoresApp1.Web.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var model = CustomerLogic.GetAllCustomers();

            return View(model);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel model)
        {
                CustomerLogic.CreateNewCustomer(model);

                return RedirectToAction("Index");
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var model = CustomerLogic.GetCustomerById(id);
            return View(model);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit( CustomerViewModel model)
        {
            CustomerLogic.EditCustomer(model);

                return RedirectToAction("Index");
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var model = CustomerLogic.GetCustomerById(id);
            return View(model);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            CustomerLogic.DeleteCustomer(id);
                return RedirectToAction("Index");
        }
    }
}
