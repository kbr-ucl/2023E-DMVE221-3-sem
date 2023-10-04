using DomainCentricDemo.Application;
using DomainCentricDemo.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DomainCentricDemo.Web.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly IBookQuery _queryService;

        public IndexModel(IBookQuery queryService)
        {
            _queryService = queryService;
        }
        public List<BookViewModel> Books { get; set; }
        public void OnGet()
        {
            Books = new List<BookViewModel>();
            var bookDtos = _queryService.GetAll();
            foreach (var book in bookDtos)
            {
                Books.Add(new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Description = book.Description
                });
            }
            //bookDtos.ForEach(a => Books.Add( new BookViewModel
            //{
            //    Id = a.Id,
            //    Title = a.Title,
            //    Author = a.Author,
            //    Description = a.Description
            //}));

        }
            //Books.Add(new BookViewModel
            //{
            //    Id = 1,
            //    Title = "My Book", Author = "Bob",
            //    Description = "The Web Book"
            //});
            //Books.Add(new BookViewModel
            //{
            //    Id = 2,
            //    Title = "My Book nr 2", Author = "John",
            //    Description = "The Best Web Book"
            //});
        }
    }

