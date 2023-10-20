using System.ComponentModel.DataAnnotations;

namespace DomainCentricDemo.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
