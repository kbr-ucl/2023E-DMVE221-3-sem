using AutoMapper;
using DomainCentricDemo.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book;

public class IndexModel : PageModel
{
    private readonly IBookApiProxy _bookApi;
    private readonly IMapper _mapper;


    public IndexModel(IBookApiProxy bookApi, IMapper mapper)
    {
        _bookApi = bookApi;
        _mapper = mapper;
    }

    public IList<BookViewModel> Books { get; set; } = default!;

    public async Task OnGet()
    {
        var books = await _bookApi.GetAllAsync();
        Books = _mapper.Map<List<BookViewModel>>(books);
    }
}