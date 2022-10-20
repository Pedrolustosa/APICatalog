using APICatalog.Context;
using APICatalog.Models;
using Microsoft.AspNetCore.Mvc;

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
        [Route("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _context.Products?.FirstOrDefault(x => x.ProductId == id);

            if(product == null)
            {
                return NotFound("Not Exist this Product");
            }
            return product;
        }
    }
}
