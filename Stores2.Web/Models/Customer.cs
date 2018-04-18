using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stores2.Web.Models
{
    public class Customer
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}