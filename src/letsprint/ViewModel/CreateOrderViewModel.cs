using letsprint.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.ViewModel
{
    public class CreateOrderViewModel
    {
        [Required]
        [Range(0,4, ErrorMessage = "ProductType value must be between 0 and 4")]
        public ProductType ProductType { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
