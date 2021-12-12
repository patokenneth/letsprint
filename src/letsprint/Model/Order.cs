using letsprint.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.Model
{
    public class Order
    {
        public Guid OrderID => Guid.NewGuid();

        public ProductType ProductType { get; set; }

        public int Quantity { get; set; }

        public float RequiredBinWidth { get; set; }
    }
}
