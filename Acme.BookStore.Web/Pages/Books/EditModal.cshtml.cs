using System;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Books;

public class EditModalModel(IBookAppService bookAppService) : BookStorePageModel
{
    [HiddenInput]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateBookDto? Book { get; set; }

    private readonly IBookAppService _bookAppService = bookAppService;

    public async Task OnGetAsync(Guid id)
    {
        var bookDto = await _bookAppService.GetAsync(id);
        Book = ObjectMapper.Map<BookDto, CreateUpdateBookDto>(bookDto);
    }
}

