using Acme.BookStore.Books;
using AutoMapper;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        // Entity -> DTO
        CreateMap<Book, BookDto>();
        
        // DTO -> Entity
        CreateMap<CreateUpdateBookDto, Book>();
    }
}
