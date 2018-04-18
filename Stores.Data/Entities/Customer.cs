using System.Collections.Generic;

namespace Stores.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
