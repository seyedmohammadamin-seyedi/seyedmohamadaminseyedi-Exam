using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.DTO.DTOs;

namespace WebApiSeyyedi.Services.ServiceInterfaces
{
    public interface ICityService
    {
        Task<City> MapToEntity(CityDTO city);
        Task<CityDTO> MapToDTO(City city);
        Task<IEnumerable<CityDTO>> GetCitys();
        Task<CityDTO> GetCity(int id);
        Task<CityDTO> AddCity(CityDTO city);
        Task RemoveCity(int cityId);
        Task<CityDTO> UpdateCity(CityDTO city);
        Task<IEnumerable<CityDTO>> GetAllCityWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
