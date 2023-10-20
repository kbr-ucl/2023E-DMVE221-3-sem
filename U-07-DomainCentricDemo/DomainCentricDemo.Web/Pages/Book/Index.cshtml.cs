using DomainCentricDemo.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book;

public class IndexModel : PageModel
{
    private readonly IBookQuery _queryService;

    public IndexModel(IBookQuery queryService)
    {
        _queryService = queryService;
    }

    public IList<BookViewModel> Books { get; set; } = default!;

    public void OnGet()
    {
        Books = new List<BookViewModel>();
        var bookDtos = _queryService.GetAll();
        foreach (var book in bookDtos)
            Books.Add(new BookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                //Author = book.Author,
                Description = book.Description
            });
    }
}