using Stores.BLL.DTOs;
using Stores.Data.Context;
using Stores.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Stores.BLL
{
    public class CustomerLogic
    {
        private static readonly AppDb Db = new AppDb();
        
        public static CustomerViewModel GetCustomerById(int customerId)
        {
            return Db.Customers.Where(e => e.Id == customerId).Select(c => new CustomerViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Address=c.Address,
            }).FirstOrDefault();
        }

        public static List<CustomerViewModel> GetAllCustomers()
        {
             return Db.Customers.Select(c => new CustomerViewModel()
             {
                 Id = c.Id,
                 Name = c.Name,
                 Address=c.Address,
             }).ToList();
        }

        public static void EditCustomer(CustomerViewModel model)
        {
            var existingCustomer = Db.Customers.FirstOrDefault(x => x.Id == model.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Id = model.Id;
                existingCustomer.Name = model.Name;
                existingCustomer.Address = model.Address;
            }
            Db.SaveChanges();
        }

        public static void CreateNewCustomer(CustomerViewModel model)
        {
            try
            {
                Db.Customers.Add(new Customer()
                {
                    Id = model.Id,
                    Name=model.Name,
                    Address=model.Address,
                });
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteCustomer(int customerId)
        {
            var customer= Db.Customers.Include(x=> x.SoldProducts)
                 .SingleOrDefault(p => p.Id == customerId);


            foreach (var soldProduct in customer.SoldProducts.ToList())
                Db.SoldProducts.Remove(soldProduct);
            Db.Customers.Remove(customer);

            Db.SaveChanges();
        }


        
    }
}
