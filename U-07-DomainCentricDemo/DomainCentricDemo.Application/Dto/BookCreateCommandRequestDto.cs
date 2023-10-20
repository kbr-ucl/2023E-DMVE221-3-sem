namespace DomainCentricDemo.Application.Dto;

public class BookCreateCommandRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<int> AuthorIds { get; set; }
}