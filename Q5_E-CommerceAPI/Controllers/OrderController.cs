using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Q5_E_CommerceAPI.Models;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace Q5_E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO order)
        {
            try
            {
                var newOrder = new Orders
                {
                    ProductId = order.ProductId,
                    Piece = order.Piece,
                    Address = order.Address,
                    OrderDate = DateTime.Now
                };

                int orderpiece = newOrder.Piece;
                var product = await _context.Products.FindAsync(newOrder.ProductId);

                if (orderpiece <= product.Stock)
                {
                    var totalAmount = product.Price * orderpiece;
                    newOrder.TotalAmount = totalAmount;
                    _context.Orders.Add(newOrder);
                    await _context.SaveChangesAsync();
                    return Ok(newOrder);
                }
                else
                {
                    return Ok("Out of stock!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var content = await _context.Orders.ToListAsync();
                var jsoncontent = JsonConvert.SerializeObject(content);
                return Content(jsoncontent, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdersById(int id)
        {
            try
            {
                var content = await _context.Orders.FindAsync(id);
                var jsoncontent = JsonConvert.SerializeObject(content);
                return Content(jsoncontent, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var selected = await _context.Orders.FindAsync(id);
                _context.Orders.Remove(selected);
                _context.SaveChanges();
                return Ok("Order deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
