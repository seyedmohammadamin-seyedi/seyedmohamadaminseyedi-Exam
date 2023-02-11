using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSeyyedi.DTO.DTOs
{
    public class BookDetailDTO
    {
        public int Id { get; set; }

        public DateTime? PublishDateTime { get; set; }

        public byte? CountEdition { get; set; }

        public string? Description { get; set; }

        public int BookId { get; set; }

        public virtual BookDTO? Book { get; set; }
    }
}
