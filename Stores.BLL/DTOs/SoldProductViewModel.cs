using Stores.BLL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.BLL.DTOs
{
    public class SoldProductViewModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Product Name is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Store Name is required")]
        public int StoreId { get; set; }

        [DisplayName("Product Sold Date")]
        [Required(ErrorMessage = "Product Sold Date is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Datetime")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [ValidSoldDateAttribute(ErrorMessage = "Product Sold Date can not be greater than current date.")]
        public DateTime SoldDate { get; set; }
        
        [ForeignKey("CustomerId")]
        public virtual CustomerViewModel Customer { get; set; }
        public virtual List<CustomerViewModel> Customers { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductViewModel Product { get; set; }
        public virtual List<ProductViewModel> Products { get; set; }

        [ForeignKey("StoreId")]
        public virtual StoreViewModel Store { get; set; }
        public virtual List<StoreViewModel> Stores { get; set; }
    }
}