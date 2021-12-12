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

        
        public async Task<string> CreateItem(CreateOrderViewModel[] order)
        {
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                try
                {
                    //we create the order object to provide a unique id for all the items selected
                    Order neworder = new() {DateofOrder = DateTime.Now };
                    _dbcontext.orders.Add(neworder);

                    _dbcontext.SaveChanges();

                    var lastOrderId = _dbcontext.orders.ToList().LastOrDefault().OrderID;

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

                    //rollback transaction to maintain db integrity
                    transaction.Rollback();
                    return string.Empty;
                    
                }
                
            }

           
            
        }

        public OrderDetailsViewModel ViewOrder(string OrderID)
        {
            //check if there is an order with the given OrderID

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

                //return itemsReturned;
            }
            
            
        }
    }
}
