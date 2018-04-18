using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stores.BLL.DTOs
{
    public class CustomerViewModel
    {
        //[Key]
        public int Id { get; set; }

        [DisplayName("Customer Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "Customer Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Customer address is required")]
        public string Address { get; set; }
        public virtual List<SoldProductViewModel> SoldProducts { get; set; }
    }
}
