using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book;

// https://learn.microsoft.com/en-us/aspnet/core/security/authorization/resourcebased?view=aspnetcore-7.0
[Authorize]
public class EditModel : PageModel
{
    private readonly IBookCommand _command;
    private readonly IAuthorizationService _authorizationService;
    private readonly IBookQuery _query;

    public EditModel(IBookQuery query, IBookCommand command,IAuthorizationService authorizationService)
    {
        _query = query;
        _command = command;
        _authorizationService = authorizationService;
    }

    [BindProperty] public BookViewModel Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();



        var book = _query.Get(id.Value);
        if (book == null) return NotFound();

        var authorizationResult = await _authorizationService
            .AuthorizeAsync(User, book, "IsSoleAuthorOrAdminPolicy");

        if (authorizationResult.Succeeded)
        {
            Book = new BookViewModel
            {
                // Author = book.Author, 
                Description = book.Description,
                Title = book.Title,
                Id = book.Id
            };
            return Page();
        }
        else if (User.Identity is {IsAuthenticated: true})
        {
            return new ForbidResult();
        }
        else
        {
            return new ChallengeResult();
        }
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
            AuthorIds = new(),
            Description = Book.Description,
            Title = Book.Title,
            Id = Book.Id
        });
        return RedirectToPage("./Index");
    }
}