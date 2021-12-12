﻿using letsprint.Utility;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ItemID { get; set; } = Guid.NewGuid().ToString();

        [StringLength(50)]
        public string ProductType { get; set; }

        public int Quantity { get; set; }

        public double RequiredBinWidth { get; set; }

        public string OrderID { get; set; }

        public Order Order { get; set; }
    }
}