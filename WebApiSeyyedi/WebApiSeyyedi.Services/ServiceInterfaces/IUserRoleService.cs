using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.DTO.DTOs;

namespace WebApiSeyyedi.Services.ServiceInterfaces
{
    public interface IUserRoleService
    {
        Task<UserRole> MapToEntity(UserRoleDTO userRole);
        Task<UserRoleDTO> MapToDTO(UserRole userRole);
        Task<IEnumerable<UserRoleDTO>> GetUserRoles();
        Task<UserRoleDTO> GetUserRole(int id);
        Task<UserRoleDTO> AddUserRole(UserRoleDTO userRole);
        Task RemoveUserRole(int userRoleId);
        Task<UserRoleDTO> UpdateUserRole(UserRoleDTO userRole);
        Task<IEnumerable<UserRoleDTO>> GetAllUserRoleWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
