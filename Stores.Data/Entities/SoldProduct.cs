using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.Data.Entities
{
    public class SoldProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        
        public int CustomerId { get; set; }

        public int StoreId { get; set; }

        public DateTime SoldDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
