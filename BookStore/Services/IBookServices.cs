using BookStore.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.Services
{
    public interface IBookServices
    {
        Task<List<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookDto> UpdateBookAsync(int id, UpdateBookDto bookDto);
        Task<bool> DeleteBookAsync(int id);
    }
}
