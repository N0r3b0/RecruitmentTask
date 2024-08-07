using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Contexts;
using RecruitmentTask.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitmentTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ContactsContext _context;

        public CategoryController(ContactsContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _context.Categories
                .Include(c => c.SubCategories)
                .ToListAsync();

            // Uproszczenie danych, aby unikać cyklicznych odwołań
            var result = categories.Select(c => new
            {
                c.Id,
                c.Name,
                SubCategories = c.SubCategories.Select(sc => new { sc.Id, sc.Name }).ToList()
            });

            return Ok(result);
        }

        // GET: api/Category/{categoryName}/SubCategories
        [HttpGet("{categoryName}/SubCategories")]
        public async Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategories(string categoryName)
        {
            var category = await _context.Categories.Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Name == categoryName);

            if (category == null)
            {
                return NotFound();
            }

            var result = category.SubCategories.Select(sc => new { sc.Id, sc.Name });

            return Ok(result);
        }
    }
}
