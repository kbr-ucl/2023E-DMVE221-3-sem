public class WebMapperProfile : Profile
{
    public WebMapperProfile()
    {
        CreateMap<BookViewModel, BookDto>().ReverseMap();
        CreateMap<BookViewModel, BookCommandRequestDto>();
        CreateMap<BookViewModel, BookUpdateRequestDto>();
    }
}
