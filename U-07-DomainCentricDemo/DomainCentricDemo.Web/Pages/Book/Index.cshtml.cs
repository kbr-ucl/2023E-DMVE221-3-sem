using AutoMapper;
using DomainCentricDemo.Application;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book;

public class IndexModel : PageModel
{
    private readonly IBookQuery _queryService;
    private readonly IMapper _mapper;

    public IndexModel(IBookQuery queryService,  IMapper mapper)
    {
        _queryService = queryService;
        _mapper = mapper;
    }

    public IList<BookViewModel> Books { get; set; } = default!;

    public void OnGet()
    {
        var bookDtos = _queryService.GetAll();
        // https://stackoverflow.com/questions/1623993/mapping-collections-using-automapper
        Books = _mapper.Map<List<BookViewModel>>(bookDtos);
    }
}