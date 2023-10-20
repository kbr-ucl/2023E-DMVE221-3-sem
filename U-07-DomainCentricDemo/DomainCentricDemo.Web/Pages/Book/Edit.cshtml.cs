using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book;

public class EditModel : PageModel
{
    private readonly IBookCommand _command;
    private readonly IBookQuery _query;

    public EditModel(IBookQuery query, IBookCommand command)
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
            // Author = book.Author, 
            Description = book.Description,
            Title = book.Title,
            Id = book.Id
        };
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _command.Update(new BookUpdateRequestDto
        {
            //Author = Book.Author, 
            Description = Book.Description,
            Title = Book.Title,
            Id = Book.Id
        });
        return RedirectToPage("./Index");
    }
}