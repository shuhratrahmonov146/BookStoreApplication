using AutoMapper;
using BookStore.Data;
using BookStore.Dtos;

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
        }fgfgfgf

        public Task<bool> DeleteBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookDto>> GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetBookByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> UpdateBookAsync(int id, UpdateBookDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}
