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
        public IActionResult GetOrderByID(Int64 OrderID)
        {
            if (OrderID < 0)
            {
                return BadRequest(new { message = "Enter a valid OrderID"});
            }

            var orderdetails = _orderRepo.ViewOrder(OrderID);

            if (orderdetails == null)
            {
                return NotFound(new { message = "The OrderID you entered is not found."});
            }
            return Ok(orderdetails);
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel[] order)
        {
            
            if (ModelState.IsValid)
            {
                var orderid = await _orderRepo.CreateItem(order);

                if (orderid == -1)
                {
                    return UnprocessableEntity(new { message = "Product type value must be between 0 and 4 and Quantity must be greater than 0."});
                }

                if (orderid == -200)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
                }
                return CreatedAtRoute("GetByID", new { OrderID = orderid }, order);
                
            }
            
            return BadRequest();
        }
    }
}
