using AutoMapper;
using BookStore.Dtos;
using BookStore.Models;

namespace BookStore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>()
            .ForMember(dest => dest.Authors, opt => opt.Ignore());

        }
    }
}
