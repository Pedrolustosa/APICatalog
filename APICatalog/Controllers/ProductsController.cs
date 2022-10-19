using APICatalog.Context;
using Microsoft.AspNetCore.Mvc;

namespace APICatalog.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

    }
}
