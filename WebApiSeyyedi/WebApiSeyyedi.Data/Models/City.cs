using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSeyyedi.Data.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; } = null!;
        public virtual ICollection<Library> Libraries { get; } = new List<Library>();
    }
}
