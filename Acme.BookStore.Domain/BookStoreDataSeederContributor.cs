using System;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore;

public class BookStoreDataSeeder : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;

    public BookStoreDataSeeder(IRepository<Book, Guid> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.CountAsync() == 0)
        {
            await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.99f
                },
                autoSave: true
            );

            _ = await _bookRepository.InsertAsync(
                new Book
                {
                    Name = "The Hobbit",
                    Type = BookType.Fantasy,
                    PublishDate = new DateTime(1937, 9, 21),
                    Price = 25.99f
                },
                autoSave: true
            );
        }
    }
}