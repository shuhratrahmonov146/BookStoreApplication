using BookStore.Models;

namespace BookStore.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public List<AuthorDto> Authors { get; set; }
    }
}
