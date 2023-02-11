using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.DTO.DTOs;

namespace WebApiSeyyedi.Services.ServiceInterfaces
{
    public interface ICategoryService
    {
        Task<Category> MapToEntity(CategoryDTO category);
        Task<CategoryDTO> MapToDTO(Category category);
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategory(int id);
        Task<CategoryDTO> AddCategory(CategoryDTO category);
        Task RemoveCategory(int categoryId);
        Task<CategoryDTO> UpdateCategory(CategoryDTO category);
        Task<IEnumerable<CategoryDTO>> GetAllCategoryWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
