using Stores.BLL.DTOs;
using Stores.Data.Context;
using Stores.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Stores.BLL
{
    public class StoreLogic
    {
        private static readonly AppDb Db = new AppDb();

        public static StoreViewModel GetStoreById(int storeId)
        {
            return Db.Stores.Where(e => e.Id == storeId).Select(c => new StoreViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address
            }).FirstOrDefault();
        }

        public static List<StoreViewModel> GetAllStores()
        {
            return Db.Stores.Select(c => new StoreViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
            }).ToList();
        }

        public static void EditStore(StoreViewModel model)
        {
            var existingStore = Db.Stores.FirstOrDefault(x => x.Id == model.Id);
            if (existingStore != null)
            {
                existingStore.Id = model.Id;
                existingStore.Name = model.Name;
                existingStore.Address = model.Address;
            }
            Db.SaveChanges();
        }

        public static void CreateNewStore(StoreViewModel model)
        {
            try
            {
                Db.Stores.Add(new Store()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Address = model.Address,
                });
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteStore(int storeId)
        {
            var store = Db.Stores.Include(x => x.SoldProducts)
                 .SingleOrDefault(p => p.Id == storeId);


            foreach (var soldProduct in store.SoldProducts.ToList())
                Db.SoldProducts.Remove(soldProduct);
            Db.Stores.Remove(store);

            Db.SaveChanges();

        }
    }
}
