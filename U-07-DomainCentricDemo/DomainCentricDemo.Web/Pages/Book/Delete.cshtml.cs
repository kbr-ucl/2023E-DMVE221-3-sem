using DomainCentricDemo.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DomainCentricDemo.Web.Pages.Book;

public class DeleteModel : PageModel
{   private readonly IBookCommand _command;
    private readonly IBookQuery _query;

    public DeleteModel(IBookQuery query, IBookCommand command)
    {
        _query = query;
        _command = command;
    }
    [BindProperty] public BookViewModel Book { get; set; } = default!;

    public IActionResult OnGet(int? id)
    {
        if (id == null) return NotFound();

        var book = _query.Get(id.Value);
        if (book == null) return NotFound();
        
        Book = new BookViewModel
        {
            Author = book.Author, 
            Description = book.Description, 
            Title = book.Title,
            Id = book.Id
        };
        return Page();
    }

    public IActionResult OnPost(int? id)
    {
        if (id == null) return NotFound();

        _command.Delete(id.Value);

        return RedirectToPage("./Index");
    }
}