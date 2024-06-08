using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookStore.Models;
using BookStore.Data;
using BookStore.Dtos;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            var books = await _context.Books.Include(b => b.Authors).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, UpdateBookDto bookDto)
        {
  
            var existingBook = await _context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }
            _mapper.Map(bookDto, existingBook);

            var authors = await _context.Authors.Where(a => bookDto.AuthorIds.Contains(a.Id)).ToListAsync();
            existingBook.Authors.Clear();
            existingBook.Authors.AddRange(authors);

            _context.Entry(existingBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(b => b.Id == id))
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

        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);

            var authors = await _context.Authors
                                        .Where(a => createBookDto.AuthorIds.Contains(a.Id))
                                        .ToListAsync();

            book.Authors.AddRange(authors);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var bookDto = _mapper.Map<BookDto>(book);

            return CreatedAtAction("GetBook", new { id = bookDto.Id }, bookDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
