using Stores.BLL.DTOs;
using Stores.Data.Context;
using Stores.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stores.BLL
{
    public class SoldProductLogic
    {
        private static readonly AppDb Db = new AppDb();

        public static SoldProductViewModel GetSoldProductById(int soldProductId)
        {
            return Db.SoldProducts.Where(sp => sp.Id == soldProductId).Select(spvm => new SoldProductViewModel()
            {
                Id = spvm.Id,
                CustomerId = spvm.CustomerId,
                StoreId = spvm.StoreId,
                ProductId = spvm.ProductId,
                SoldDate = spvm.SoldDate,

                Customer = new CustomerViewModel()
                {
                    Id = spvm.Customer.Id,
                    Name = spvm.Customer.Name,
                    Address = spvm.Customer.Address,
                },

                Product = new ProductViewModel()
                {
                    Id = spvm.Product.Id,
                    Name = spvm.Product.Name,
                    Price = spvm.Product.Price,
                },

                Store = new StoreViewModel()
                {
                    Id = spvm.Store.Id,
                    Name = spvm.Store.Name,
                    Address = spvm.Store.Address,
                },
            }).FirstOrDefault();
        }

        public static List<SoldProductViewModel> GetAllSoldProducts()
        {
            return Db.SoldProducts.Select(sp => new SoldProductViewModel()
            {
                Id = sp.Id,
                CustomerId = sp.CustomerId,
                StoreId = sp.StoreId,
                ProductId = sp.ProductId,
                SoldDate = sp.SoldDate,

                Customer = new CustomerViewModel()
                {
                    Id = sp.Customer.Id,
                    Name = sp.Customer.Name,
                    Address = sp.Customer.Address,
                },

                Product = new ProductViewModel()
                {
                    Id = sp.Product.Id,
                    Name = sp.Product.Name,
                    Price = sp.Product.Price,
                },

                Store = new StoreViewModel()
                {
                    Id = sp.Store.Id,
                    Name = sp.Store.Name,
                    Address = sp.Store.Address,
                },
            }).ToList();
        }

        public static SoldProductViewModel GetAllInitialData()
        {
            var cutomers = CustomerLogic.GetAllCustomers() ;
            var products = ProductLogic.GetAllProducts();
            var stores = StoreLogic.GetAllStores();


            return new SoldProductViewModel()
            {
                Customers = cutomers,
                Stores = stores,
                Products = products,
                SoldDate = DateTime.Today
            };
        }

        public static void EditSoldProduct(SoldProductViewModel model)
        {
            var existingSoldProduct = Db.SoldProducts.FirstOrDefault(sp => sp.Id == model.Id);
            if (existingSoldProduct != null)
            {
                existingSoldProduct.Id = model.Id;
                existingSoldProduct.SoldDate = model.SoldDate;
                existingSoldProduct.ProductId = model.ProductId;
                //existingSoldProduct.Product = new Product() {
                //    Id = model.Product.Id,
                //    Name= model.Product.Name,
                //    Price= model.Product.Price
                //};
                existingSoldProduct.CustomerId = model.CustomerId;
                //existingSoldProduct.Customer = new Customer()
                //{
                //    Id = model.Customer.Id,
                //    Name = model.Customer.Name,
                //    Address = model.Customer.Address
                //};
                existingSoldProduct.StoreId = model.StoreId;
                //existingSoldProduct.Store = new Store()
                //{
                //    Id = model.Store.Id,
                //    Name = model.Store.Name,
                //    Address = model.Store.Address
                //};
            }
            Db.SaveChanges();
        }

        public static void CreateNewSoldProduct(SoldProductViewModel model)
        {
            try
            {
                Db.SoldProducts.Add(new SoldProduct()
                {
                    Id = model.Id,
                    CustomerId = model.CustomerId,
                    StoreId = model.StoreId,
                    ProductId = model.ProductId,
                    SoldDate = model.SoldDate,

                    
                });
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteSoldProduct(int soldProductId)
        {
            var soldProduct = Db.SoldProducts.Find(soldProductId);
            Db.SoldProducts.Remove(soldProduct);
            Db.SaveChanges();
        }
    }
}
