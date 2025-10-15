using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Books
{
    public class CreateModalModel(IBookAppService bookAppService) : BookStorePageModel
    {
        [BindProperty]
        public CreateUpdateBookDto? Book { get; set; }

        private readonly IBookAppService _bookAppService = bookAppService;

        public void OnGet()
        {
            Book = new CreateUpdateBookDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            _ = await _bookAppService.CreateAsync(Book);
#pragma warning restore CS8604 // Possible null reference argument.
            return NoContent();
        }
    }
}
