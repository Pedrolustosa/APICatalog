using APICatalog.Models;
using APICatalog.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategoryWithProducts()
        {
            return _context.Categories.Include(p => p.Products).Where(c => c.CategoryId <= 5).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _context.Categories?.ToList();
            if (categories is null)
            {
                return NotFound("Haven't categories");
            }
            return categories;
        }

        [HttpGet]
        [Route("{id}", Name = "NewCategory")]
        public ActionResult<Category> GetById(int categoryId)
        {
            var category = _context.Categories?.FirstOrDefault(x => x.CategoryId == categoryId);

            if (category == null)
            {
                return NotFound("Not Exist this Category");
            }
            return category;
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (category == null)
                return BadRequest();

            _context.Categories?.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("NewCategory", new { id = category.CategoryId }, category);
        }

        [HttpPut]
        [Route("{categoryId}")]
        public ActionResult Put(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete]
        [Route("categoryId")]
        public ActionResult Remove(int categoryId)
        {
            var category = _context.Categories?.FirstOrDefault(p => p.CategoryId == categoryId);


            if (category is null)
            {
                return NotFound("Not exist this Category!");
            }

            _context.Categories?.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }
    }
}
