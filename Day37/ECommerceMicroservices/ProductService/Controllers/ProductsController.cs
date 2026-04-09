

//using Microsoft.AspNetCore.Mvc;
//using ProductService.Models;

//namespace ProductService.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//        private readonly ProductDbContext _context;

//        public ProductsController(ProductDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            return Ok(_context.Products.ToList());
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetById(int id)
//        {
//            var product = _context.Products.FirstOrDefault(p => p.Id == id);

//            if (product == null)
//                return NotFound("Product not found");

//            return Ok(product);
//        }

//        [HttpPost]
//        public IActionResult Create(Product product)
//        {
//            _context.Products.Add(product);
//            _context.SaveChanges();
//            return Ok(product);
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;

using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }
    }
}