using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSeyyedi.Data.Models
{
    public class Province
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<City> Citys { get; } = new List<City>();
    }
}
