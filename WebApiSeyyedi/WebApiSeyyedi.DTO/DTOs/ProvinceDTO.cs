using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSeyyedi.DTO.DTOs
{
    public class ProvinceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityDTO> Cities { get; set; }
    }
}
