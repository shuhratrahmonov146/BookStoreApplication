using BookStore.Dtos;

namespace BookStore.Services
{
    public interface IBookServices
    {
        Task<List<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookDto> UpdateBookAsync(int id, UpdateBookDto bookDto);
        Task<BookDto> AddBookAsync(CreateBookDto createBookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}
