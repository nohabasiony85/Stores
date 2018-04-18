using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stores.BLL.DTOs
{
    public class StoreViewModel
    {
        public int Id { get; set; }

        [DisplayName("Store Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "Store Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Store address is required")]
        public string Address { get; set; }
        public virtual List<SoldProductViewModel> SoldProducts { get; set; }
    }
}