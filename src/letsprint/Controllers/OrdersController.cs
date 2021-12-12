using letsprint.Infrastructure.Interface;
using letsprint.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace letsprint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrder _orderRepo;

        public OrdersController(IOrder orderRepo)
        {
            _orderRepo = orderRepo;
        }

        [HttpGet(template: "{OrderID}", Name = "GetByID")]
        public IActionResult GetOrderByID(string OrderID)
        {
            if (string.IsNullOrEmpty(OrderID))
            {
                return BadRequest(new { message = "OrderID cannot be empty"});
            }

            var orderdetails = _orderRepo.ViewOrder(OrderID);

            return Ok(orderdetails);
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel[] order)
        {
            if (ModelState.IsValid)
            {
                var orderid = await _orderRepo.CreateItem(order);

                if (orderid == string.Empty)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
                }
                return CreatedAtRoute("GetByID", new { OrderID = orderid }, order);
                
            }

            return BadRequest();
        }
    }
}
