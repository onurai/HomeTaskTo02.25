using HomeTaskTo02._25.Data.Context;
using HomeTaskTo02._25.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskTo02._25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BooksController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _db.Books.Select(x => x.BookName).ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _db.Books.FirstOrDefaultAsync(x => x.BookId == id);
            return Ok(book);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBook(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return Ok(book);    
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            var existedBook = await _db.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (existedBook == null) return NotFound();   
            existedBook.BookName = book.BookName;
            existedBook.Author = book.Author;
            existedBook.Price = book.Price;
            await _db.SaveChangesAsync();   
            return Ok(existedBook);
        }

        [HttpDelete("{id}")]
        public async Task DeleteBook(int id)
        {
            var existedBook = await _db.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if(existedBook != null)
            {
                _db.Books.Remove(existedBook);
                await _db.SaveChangesAsync();
            }
             NotFound();
            
            //I wrote this here to see all books with the exception of book that I deleted to make sure of this operation
        }
    }
}
