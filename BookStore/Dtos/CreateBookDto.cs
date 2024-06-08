using BookStore.Models;

namespace BookStore.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
