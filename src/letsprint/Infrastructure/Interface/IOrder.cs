using letsprint.Model;
using letsprint.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.Infrastructure.Interface
{
    public interface IOrder
    {
        Task<Int64> CreateItem(CreateOrderViewModel[] order);
        OrderDetailsViewModel ViewOrder(Int64 OrderID);
    }
}
