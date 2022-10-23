using APICatalog.Context;
using APICatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _context.Products?.ToList();
            if(products is null)
            {
                return NotFound("Haven't Products");
            }
            return products;
        }

        [HttpGet]
        [Route("{id}", Name = "NewProduct")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _context.Products?.FirstOrDefault(x => x.ProductId == id);

            if(product == null)
            {
                return NotFound("Not Exist this Product");
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            if (product == null)
                return BadRequest();

            _context.Products?.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("NewProduct", new { id = product.ProductId }, product);
        }

        [HttpPut]
        [Route("{productId}")]
        public ActionResult Put(int productId, Product product)
        {
            if (productId != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        }
    }
}
