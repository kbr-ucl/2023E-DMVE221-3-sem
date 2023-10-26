using AutoMapper;
using DomainCentricDemo.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book;

public class DeleteModel : PageModel
{
    private readonly IBookCommand _command;
    private readonly IMapper _mapper;
    private readonly IBookQuery _query;

    public DeleteModel(IBookQuery query, IBookCommand command, IMapper mapper)
    {
        _query = query;
        _command = command;
        _mapper = mapper;
    }

    [BindProperty] public BookViewModel Book { get; set; } = default!;

    public IActionResult OnGet(int? id)
    {
        if (id == null) return NotFound();

        var book = _query.Get(id.Value);
        if (book == null) return NotFound();

        Book = _mapper.Map<BookViewModel>(book);

        return Page();
    }

    public IActionResult OnPost(int? id)
    {
        if (id == null) return NotFound();

        _command.Delete(id.Value);

        return RedirectToPage("./Index");
    }
}