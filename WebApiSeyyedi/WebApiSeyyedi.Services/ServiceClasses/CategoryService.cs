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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CategoryDTO> AddCategory(CategoryDTO category)
        {
            var data = await MapToEntity(category);
            await _unitOfWork.CategoryRepository.Add(data);
            await _unitOfWork.Commit();
            return category;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoryWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var categories = await _unitOfWork.CategoryRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(s => s.Name);
                    break;
                default:
                    categories = categories.OrderBy(s => s.Name);
                    break;
            }
            pageSize = pageSize.HasValue ? pageSize : 0;
            int pageNumber = (page ?? 1);
            categories = categories.Skip(pageSize.Value * pageNumber).Take(pageSize.Value);
            return categories != null && categories.Any() ? categories.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            IQueryable<Category> datas = await _unitOfWork.CategoryRepository.GetAll();
            return datas != null && datas.Any() ? datas.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
            var data = await _unitOfWork.CategoryRepository.GetById(id);
            return await MapToDTO(data);
        }

        public async Task<CategoryDTO> MapToDTO(Category category)
        {
            return new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task<Category> MapToEntity(CategoryDTO category)
        {
            return await Task.Run(() => new Category()
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        public async Task RemoveCategory(int categoryId)
        {
            await _unitOfWork.CategoryRepository.Delete(await _unitOfWork.CategoryRepository.GetById(categoryId));
            await _unitOfWork.Commit();
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO category)
        {
            var data = await _unitOfWork.CategoryRepository.Add(await MapToEntity(category));
            await _unitOfWork.Commit();
            return await MapToDTO(data);
        }
    }
}
