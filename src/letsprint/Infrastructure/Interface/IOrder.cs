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
        Task<string> CreateItem(CreateOrderViewModel[] order);
        OrderDetailsViewModel ViewOrder(string OrderID);
    }
}
