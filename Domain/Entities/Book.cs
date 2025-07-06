using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }


        public Author? Author { get; set; }
    }
}
