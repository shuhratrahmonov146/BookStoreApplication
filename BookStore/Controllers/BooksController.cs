using Microsoft.AspNetCore.Mvc;
using BookStore.Dtos;
using BookStore.Services;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;

        public BooksController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            var books = await _bookServices.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookServices.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);    
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, UpdateBookDto bookDto)
        {
  
            var result = await _bookServices.DeleteBookAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> PostBook(CreateBookDto createBookDto)
        {
            var newBook = await _bookServices.AddBookAsync(createBookDto);
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookServices.DeleteBookAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent(); 
        }
    }
}
