﻿namespace DomainCentricDemo.Web.Infrastructure.Dto;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<AuthorDto> Authors { get; set; } = new();
}