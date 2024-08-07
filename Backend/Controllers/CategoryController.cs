using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Contexts;
using RecruitmentTask.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            return await _context.Categories.Include(c => c.SubCategories).ToListAsync();
        }
    }
}
