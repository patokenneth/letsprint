using letsprint.DAL;
using letsprint.DTO;
using letsprint.Infrastructure.Interface;
using letsprint.Model;
using letsprint.Utility;
using letsprint.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.Infrastructure.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly PrintContext _dbcontext;

        public OrderRepository(PrintContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        
        public async Task<int> CreateItem(CreateOrderViewModel[] order)
        {
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    //check that product type is defined and quantity is greater than zero

                    if (order.Any(o => !Enum.IsDefined(typeof(ProductType), o.ProductType)) || order.Any(o => o.Quantity <= 0))
                    {
                        return -1;
                    }

                    //first, I created an order record to provide a unique common id for the items selected

                    Order neworder = new() {DateofOrder = DateTime.Now };
                    _dbcontext.orders.Add(neworder);

                    _dbcontext.SaveChanges();

                    var lastOrderId = _dbcontext.orders.OrderBy(o => o.OrderID).ToList().LastOrDefault().OrderID;

                    foreach (var item in order)
                    {
                        OrderDetails newitem = new()
                        {
                            ProductType = Enum.GetName(item.ProductType),
                            Quantity = item.Quantity,
                            RequiredBinWidth = WidthCalculator.CalculateWidth(item.ProductType, item.Quantity),
                            OrderID = lastOrderId
                        };

                       _dbcontext.orderdetails.Add(newitem);
                       
                    }

                    await _dbcontext.SaveChangesAsync();

                    //if we got here, commit transaction
                    transaction.Commit();
                    return lastOrderId;
                }
                catch (Exception ex)
                {
                    //log exception message if logging is enabled

                    //if something fails, rollback transaction to maintain db integrity
                    transaction.Rollback();
                    return -200;
                    
                }
                
            }

        }

        public OrderDetailsViewModel ViewOrder(int OrderID)
        {
            //check if there is an order record with the given OrderID

            if (!_dbcontext.orders.Any(O => O.OrderID == OrderID))
            {
                return null;
            }
            else
            {
                var AllOrderItems = _dbcontext.orderdetails.Include(o => o.Order).Where(i => i.Order.OrderID == OrderID);

                List<ViewOrder> orderdeets = new List<ViewOrder>();

                //transfrom all the fetched items and return just the necessary properties

                foreach (OrderDetails item in AllOrderItems.ToList())
                {
                    orderdeets.Add(new ViewOrder { ProductType = item.ProductType, Quantity = item.Quantity });
                }

                var requiredBinWidth = AllOrderItems.Sum(b => b.RequiredBinWidth) + "mm";

                //return the orders with the required bin width
                return AllOrderItems.Select(a => new OrderDetailsViewModel { orders = orderdeets, RequiredBinWith = requiredBinWidth}).FirstOrDefault();

            }
            
            
        }
    }
}
