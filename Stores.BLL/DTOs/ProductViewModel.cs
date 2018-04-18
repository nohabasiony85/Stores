using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stores.BLL.DTOs
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "Product Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Price is required")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Invalid Product price.")]
        public decimal Price { get; set; }
        public virtual List<SoldProductViewModel> SoldProducts { get; set; }

    }
}