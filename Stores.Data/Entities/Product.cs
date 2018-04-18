using System.Collections.Generic;

namespace Stores.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
