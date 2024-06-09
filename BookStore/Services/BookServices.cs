using AutoMapper;
using BookStore.Data;
using BookStore.Dtos;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class BookServices : IBookServices
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookServices(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDto> AddBookAsync(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);

            var authors = await _context.Authors
                                        .Where(a => createBookDto.AuthorIds.Contains(a.Id))
                                        .ToListAsync();

            book.Authors.AddRange(authors);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
            
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _context.Books.Include(b => b.Authors).ToListAsync();
            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return null;
            }

            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> UpdateBookAsync(int id, UpdateBookDto bookDto)
        {

            var existingBook = await _context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);
            if (existingBook == null)
            {
                return null;
            }

       
            _mapper.Map(bookDto, existingBook);


            var authors = await _context.Authors.Where(a => bookDto.AuthorIds.Contains(a.Id)).ToListAsync();

       
            existingBook.Authors.Clear();
            existingBook.Authors.AddRange(authors);

            _context.Entry(existingBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return _mapper.Map<BookDto>(existingBook);
        }
    }
}
