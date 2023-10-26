using AutoMapper;
using DomainCentricDemo.Application.Dto;
using DomainCentricDemo.Web.Pages.Book;

namespace DomainCentricDemo.Web.Mapper;

/// <summary>
///     <remarks>
/// https://docs.automapper.org/en/stable/Getting-started.html
/// https://stackoverflow.com/questions/71216149/how-to-setup-automapper-in-asp-net-core-6
/// https://stackoverflow.com/questions/1623993/mapping-collections-using-automapper
/// 
///     </remarks>
/// </summary>
public class WebMapperProfile : Profile
{
    public WebMapperProfile()
    {
        CreateMap<BookViewModel, BookDto>().ReverseMap();
        CreateMap<BookViewModel, BookCommandRequestDto>();
        CreateMap<BookViewModel, BookUpdateRequestDto>();
    }
}