using letsprint.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.Model
{
    public class OrderDetails
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ItemID { get; set; }

        [StringLength(50)]
        [Required]
        public string ProductType { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public double RequiredBinWidth { get; set; }

        [Required]
        public Int64 OrderID { get; set; }

        public Order Order { get; set; }
    }
}
