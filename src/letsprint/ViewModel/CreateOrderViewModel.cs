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
        public ProductType ProductType { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
