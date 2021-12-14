using letsprint.Controllers;
using letsprint.DTO;
using letsprint.Infrastructure.Interface;
using letsprint.Infrastructure.Repository;
using letsprint.Model;
using letsprint.Utility;
using letsprint.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace letsprint_test
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrder> _mockOrderRepo;

        public OrderControllerTests()
        {
            _mockOrderRepo = new Mock<IOrder>();
        }

        [Fact]
        public void GetOrderByID_GetOrderDetails_WhenOrderIDExists()
        {
            //Arrange
            var allOrders = GetOrderDetails(1);
            _mockOrderRepo.Setup(r => r.ViewOrder(1)).Returns(allOrders);
            var controller = new OrdersController(_mockOrderRepo.Object);

            //Act
            IActionResult actionResult = controller.GetOrderByID(1);
            var returnedContent = actionResult as Microsoft.AspNetCore.Mvc.OkObjectResult;

            //Assert
            Assert.NotNull(returnedContent);
            Assert.Equal(allOrders, returnedContent.Value);
        }

        [Fact]
        public void GetOrderByID_ReturnsNotFound_WhenOrderIDDoesNotExist()
        {
            //Arrange
            var controller = new OrdersController(_mockOrderRepo.Object);

            //Act
            IActionResult actionResult = controller.GetOrderByID(4);
           
            //Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundObjectResult>(actionResult);
            
           
        }

        [Fact]
        public void CreateOrder_CreatedAtLocation_PassingOrderItem()
        {
            //Arrange
            var producttype = (ProductType)2;
            var quantity = 3;

            var createOrderModel = new CreateOrderViewModel[] { new CreateOrderViewModel { ProductType = producttype, Quantity = quantity}};
            var controller = new OrdersController(_mockOrderRepo.Object);

            //Act
            var actionResult = controller.CreateOrder(createOrderModel);
            var response = actionResult.Result;

            //Assert
            Assert.IsType<CreatedAtRouteResult>(response);
            

        }









        private OrderDetailsViewModel GetOrderDetails(int OrderID)
        {
            List<OrderDetails> allOrderItems = new List<OrderDetails>
            {
                new OrderDetails{ItemID = 1, ProductType = "photoBook", Quantity = 2, RequiredBinWidth = 38, OrderID = 1},

                new OrderDetails{ItemID = 2, ProductType = "cards", Quantity = 2, RequiredBinWidth = 9.4, OrderID = 1},

                new OrderDetails{ItemID = 3, ProductType = "calendar", Quantity = 5, RequiredBinWidth = 50, OrderID = 2}
            };

            List<ViewOrder> orderdeets = new List<ViewOrder>();

            foreach (OrderDetails item in allOrderItems.Where(i => i.OrderID == OrderID))
            {
                orderdeets.Add(new ViewOrder { ProductType = item.ProductType, Quantity = item.Quantity });
            }

            var requiredBinWidth = allOrderItems.Where(i => i.OrderID == OrderID).Sum(b => b.RequiredBinWidth) + "mm";

            return allOrderItems.Select(a => new OrderDetailsViewModel { orders = orderdeets, RequiredBinWidth = requiredBinWidth }).FirstOrDefault();


        }
    }
}
