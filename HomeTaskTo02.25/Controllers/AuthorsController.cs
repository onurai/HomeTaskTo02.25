using HomeTaskTo02._25.Data.Context;
using HomeTaskTo02._25.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskTo02._25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AuthorsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _db.Authors.Include(x => x.Books).Select(x => x.AuthorName).ToListAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _db.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
            return Ok(author);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAuthor(Author author)
        {
            await _db.Authors.AddAsync(author);
            await _db.SaveChangesAsync();
            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, Author author)
        {
            var existedAuthor = await _db.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
            if (existedAuthor == null) return NotFound();
            existedAuthor.AuthorName = author.AuthorName;
            await _db.SaveChangesAsync();
            return Ok(existedAuthor);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAuthor(int id)
        {
            var existedAuthor = await _db.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
            if (existedAuthor != null)
            {
                _db.Authors.Remove(existedAuthor);
                await _db.SaveChangesAsync();
            }
            NotFound();
            
            //I wrote this here to see all books with the exception of book that I deleted to make sure of this operation
        }
    }
}
