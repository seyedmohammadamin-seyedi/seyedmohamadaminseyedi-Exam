using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSeyyedi.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string AuthorName { get; set; } = null!;

        public decimal Price { get; set; }

        public int LibraryId { get; set; }

        public int CategoryId { get; set; }


        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<BookDetail> BookDetails { get; } = new List<BookDetail>();

        public virtual Library Library { get; set; } = null!;
    }
}
