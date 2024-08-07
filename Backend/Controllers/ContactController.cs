using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using RecruitmentTask.Contexts;
using RecruitmentTask.Models;
using System.Security.Claims;

namespace RecruitmentTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactsContext _context;

        public ContactController(ContactsContext context)
        {
            _context = context;
        }

        // GET: api/Contact
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest("Invalid user ID");
            }

            return await _context.Contacts.Where(c => c.UserId == userId).ToListAsync();
        }

        // GET: api/Contact/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest("Invalid user ID");
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/Contact/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId) || contact.UserId != userId)
            {
                return BadRequest("Invalid user ID or unauthorized");
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            if (contact.Category == "Business")
            {
                var category = await _context.Categories.Include(c => c.SubCategories)
                                                        .FirstOrDefaultAsync(c => c.Name == "Business");
                if (category == null || !category.SubCategories.Any(sc => sc.Name == contact.SubCategory))
                {
                    return BadRequest("Invalid subcategory for Business category.");
                }
            }
            else if (contact.Category == "Other")
            {
                // Check if the subcategory already exists in the database
                var subCategory = await _context.SubCategories
                    .FirstOrDefaultAsync(sc => sc.Name == contact.SubCategory && sc.CategoryId == null);

                if (subCategory == null)
                {
                    // Add new subcategory to the database
                    subCategory = new SubCategory
                    {
                        Name = contact.SubCategory,
                        CategoryId = 3 // 3 --> OTHER
                    };

                    _context.SubCategories.Add(subCategory);
                    await _context.SaveChangesAsync();
                }
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Contact
        [Authorize]
        [HttpPost]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            contact.UserId = userId;

            if (contact.Category == "Business")
            {
                var category = await _context.Categories.Include(c => c.SubCategories)
                                                        .FirstOrDefaultAsync(c => c.Name == "Business");
                if (category == null || !category.SubCategories.Any(sc => sc.Name == contact.SubCategory))
                {
                    return BadRequest("Invalid subcategory for Business category.");
                }
            }
            else if (contact.Category == "Other")
            {
                // Check if the subcategory already exists in the database
                var subCategory = await _context.SubCategories
                    .FirstOrDefaultAsync(sc => sc.Name == contact.SubCategory && sc.CategoryId == null);

                if (subCategory == null)
                {
                    // Add new subcategory to the database
                    subCategory = new SubCategory
                    {
                        Name = contact.SubCategory,
                        CategoryId = 3 // 3 --> OTHER
                    };

                    _context.SubCategories.Add(subCategory);
                    await _context.SaveChangesAsync();
                }
            }

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }


        // DELETE: api/Contact/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId))
            {
                return BadRequest("Invalid user ID");
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId);

            if (contact == null)
            {
                return NotFound();
            }

            // Usuwanie powiązanych podkategorii, jeśli kategoria to "Other"
            if (contact.Category == "Other" && !string.IsNullOrEmpty(contact.SubCategory))
            {
                // CategoryId dla "Other" to 3
                var subCategory = await _context.SubCategories
                    .FirstOrDefaultAsync(sc => sc.Name == contact.SubCategory && sc.CategoryId == 3);

                if (subCategory != null)
                {
                    _context.SubCategories.Remove(subCategory);
                }
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }

        private async Task<bool> ValidateCategoryAndSubCategory(Contact contact)
        {
            var category = await _context.Categories.Include(c => c.SubCategories)
                                                    .FirstOrDefaultAsync(c => c.Name == contact.Category);
            if (category == null)
            {
                return false;
            }

            if (contact.Category == "Business" && !category.SubCategories.Any(sc => sc.Name == contact.SubCategory))
            {
                return false;
            }

            return true;
        }
    }
}
