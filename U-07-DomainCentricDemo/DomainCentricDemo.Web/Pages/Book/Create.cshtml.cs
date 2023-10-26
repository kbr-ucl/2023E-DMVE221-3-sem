using AutoMapper;
using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book;

public class CreateModel : PageModel
{
    private readonly IBookCommand _bookCommand;
    private readonly IMapper _mapper;

    // https://docs.automapper.org/en/stable/Dependency-injection.html
    public CreateModel(IBookCommand bookCommand, IMapper mapper)
    {
        _bookCommand = bookCommand;
        _mapper = mapper;
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

        _bookCommand.Create(_mapper.Map<BookCommandRequestDto>(Book));

        return RedirectToPage("./Index");
    }
}