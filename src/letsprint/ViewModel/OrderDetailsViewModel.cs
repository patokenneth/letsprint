using letsprint.DTO;
using letsprint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.ViewModel
{
    public class OrderDetailsViewModel
    {
        public List<ViewOrder> orders { get; set; }

        public string RequiredBinWith { get; set; }
    }
}
