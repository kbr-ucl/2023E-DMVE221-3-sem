using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book;

public class CreateModel : PageModel
{
    private readonly IBookCommand _bookCommand;

    public CreateModel(IBookCommand bookCommand)
    {
        _bookCommand = bookCommand;
    }

    [BindProperty] public BookViewModel Book { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _bookCommand.Create(new BookCreateCommandRequestDto {//AuthorIds = Book.Author, 
            Description = Book.Description,
            Title = Book.Title});

        return RedirectToPage("./Index");
    }
}