//using Microsoft.AspNetCore.Mvc;
//using OrderService.Models;

//namespace OrderService.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {
//        private readonly HttpClient _httpClient;

//        public OrdersController(IHttpClientFactory factory)
//        {
//            _httpClient = factory.CreateClient();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(Order order)
//        {
//            var product = await _httpClient
//                .GetFromJsonAsync<object>($"https://localhost:7119/api/products/{order.ProductId}");

//            if (product == null)
//                return BadRequest("Invalid Product");

//            return Ok(order);
//        }
//    }

//}
//using Microsoft.AspNetCore.Mvc;

//using OrderService.Models;
//using System.Net.Http.Json;

//namespace OrderService.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {
//        private readonly HttpClient _httpClient;
//        private readonly OrderDbContext _context;

//        public OrdersController(IHttpClientFactory factory, OrderDbContext context)
//        {
//            _httpClient = factory.CreateClient();
//            _context = context;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(Order order)
//        {
//            var product = await _httpClient.GetFromJsonAsync<ProductDTO>(
//                $"https://localhost:7119/api/products/{order.ProductId}");

//            if (product == null)
//                return BadRequest("Invalid Product");

//            order.ProductName = product.Name;

//            _context.Orders.Add(order);
//            await _context.SaveChangesAsync();

//            return Ok(order);
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            return Ok(_context.Orders.ToList());
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;

using OrderService.Models;
using System.Net.Http.Json;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly OrderDbContext _context;

        public OrdersController(IHttpClientFactory factory, OrderDbContext context)
        {
            _httpClient = factory.CreateClient();
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            var product = await _httpClient.GetFromJsonAsync<ProductDTO>(
                $"https://localhost:7119/api/products/{order.ProductId}");

            if (product == null)
                return BadRequest("Invalid Product");

            order.ProductName = product.Name;
            order.TotalPrice = product.Price * order.Quantity;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Orders.ToList());
        }
    }
}