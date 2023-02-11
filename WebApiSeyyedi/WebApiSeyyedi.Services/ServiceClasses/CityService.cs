using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.DTO.DTOs;
using WebApiSeyyedi.Infrastructure;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi.Services.ServiceClasses
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CityDTO> AddCity(CityDTO city)
        {
            var data = await MapToEntity(city);
            await _unitOfWork.CityRepository.Add(data);
            await _unitOfWork.Commit();
            return city;
        }

        public async Task<IEnumerable<CityDTO>> GetAllCityWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var citys = await _unitOfWork.CityRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                citys = citys.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    citys = citys.OrderByDescending(s => s.Name);
                    break;
                default:
                    citys = citys.OrderBy(s => s.Name);
                    break;
            }
            pageSize = pageSize.HasValue ? pageSize : 0;
            int pageNumber = (page ?? 1);
            citys = citys.Skip(pageSize.Value * pageNumber).Take(pageSize.Value);
            return citys != null && citys.Any() ? citys.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<CityDTO> GetCity(int id)
        {
            var data = await _unitOfWork.CityRepository.GetById(id);
            return await MapToDTO(data);
        }

        public async Task<IEnumerable<CityDTO>> GetCitys()
        {
            IQueryable<City> datas = await _unitOfWork.CityRepository.GetAll();
            return datas != null && datas.Any() ? datas.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<CityDTO> MapToDTO(City city)
        {
            return new CityDTO
            {
                Id = city.Id,
                Name = city.Name
            };
        }

        public async Task<City> MapToEntity(CityDTO city)
        {
            return await Task.Run(() => new City()
            {
                Id = city.Id,
                Name = city.Name
            });
        }

        public async Task RemoveCity(int cityId)
        {
            await _unitOfWork.CityRepository.Delete(await _unitOfWork.CityRepository.GetById(cityId));
            await _unitOfWork.Commit();
        }

        public async Task<CityDTO> UpdateCity(CityDTO city)
        {
            var data = await _unitOfWork.CityRepository.Add(await MapToEntity(city));
            await _unitOfWork.Commit();
            return await MapToDTO(data);
        }
    }
}
