using APICatalog.Models;
using APICatalog.Context;
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

            try
            {
                var products = _context.Products?.ToList();
                if (products is null)
                {
                    return NotFound("Haven't Products");
                }
                return products;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "NewProduct")]
        public ActionResult<Product> GetById(int id)
        {
            try
            {
                var product = _context.Products?.FirstOrDefault(x => x.ProductId == id);

                if (product == null)
                {
                    return NotFound("Not Exist this Product");
                }
                return product;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest();

                _context.Products?.Add(product);
                _context.SaveChanges();

                return new CreatedAtRouteResult("NewProduct", new { id = product.ProductId }, product);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpPut]
        [Route("{productId}")]
        public ActionResult Put(int productId, Product product)
        {
            try
            {
                if (productId != product.ProductId)
                {
                    return BadRequest();
                }

                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpDelete]
        [Route("productId")]
        public ActionResult Remove(int id)
        {
            try
            {
                var product = _context.Products?.FirstOrDefault(p => p.ProductId == id);

                if (product is null)
                {
                    return NotFound("Not exist this Product!");
                }

                _context.Products?.Remove(product);
                _context.SaveChanges();

                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
