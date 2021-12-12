﻿using letsprint.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.Model
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string OrderID { get; set; } = Guid.NewGuid().ToString();

        public DateTime DateofOrder { get; set; }

    }
}
