using Stores.BLL.DTOs;
using Stores.Data.Context;
using Stores.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Stores.BLL
{
    public class ProductLogic
    {
        private static readonly AppDb Db = new AppDb();

        public static ProductViewModel GetProductById(int productId)
        {
            return Db.Products.Where(e => e.Id == productId).Select(c => new ProductViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Price=c.Price
            }).FirstOrDefault();
        }

        public static List<ProductViewModel> GetAllProducts()
        {
            return Db.Products.Select(c => new ProductViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Price=c.Price
            }).ToList();
        }
        
        public static void EditProduct(ProductViewModel model)
        {
            var existingProduct = Db.Products.FirstOrDefault(x => x.Id == model.Id);
            if (existingProduct != null)
            {
                existingProduct.Id = model.Id;
                existingProduct.Name = model.Name;
                existingProduct.Price = model.Price;
            }
            Db.SaveChanges();
        }

        public static void CreateNewProduct(ProductViewModel model)
        {
            try
            {
                Db.Products.Add(new Product()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price,
                });
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteProduct(int productId)
        {
            var product = Db.Products.Include(x => x.SoldProducts)
                 .SingleOrDefault(p => p.Id == productId);


            foreach (var soldProduct in product.SoldProducts.ToList())
                Db.SoldProducts.Remove(soldProduct);
            Db.Products.Remove(product);

            Db.SaveChanges();
        }

    }
}
