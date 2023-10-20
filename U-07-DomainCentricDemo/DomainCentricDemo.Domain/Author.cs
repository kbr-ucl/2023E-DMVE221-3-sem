namespace DomainCentricDemo.Domain;

public class Author
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Book> Books { get; set; } = new();
}