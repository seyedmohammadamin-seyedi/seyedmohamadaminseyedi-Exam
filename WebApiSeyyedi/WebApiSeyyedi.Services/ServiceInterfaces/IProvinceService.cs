using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.DTO.DTOs;

namespace WebApiSeyyedi.Services.ServiceInterfaces
{
    public interface IProvinceService
    {
        Task<Province> MapToEntity(ProvinceDTO province);
        Task<ProvinceDTO> MapToDTO(Province province);
        Task<IEnumerable<ProvinceDTO>> GetProvinces();
        Task<ProvinceDTO> GetProvince(int id);
        Task<ProvinceDTO> AddProvince(ProvinceDTO province);
        Task RemoveProvince(int provinceId);
        Task<ProvinceDTO> UpdateProvince(ProvinceDTO province);
        Task<IEnumerable<ProvinceDTO>> GetAllProvinceWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
