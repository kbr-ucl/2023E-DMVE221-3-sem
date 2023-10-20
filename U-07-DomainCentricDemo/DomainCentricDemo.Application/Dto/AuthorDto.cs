namespace DomainCentricDemo.Application.Dto;

public class AuthorDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<BookDto> Books { get; set; }
}