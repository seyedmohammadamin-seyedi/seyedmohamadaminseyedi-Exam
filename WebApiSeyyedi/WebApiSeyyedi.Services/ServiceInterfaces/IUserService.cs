using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.DTO.DTOs;

namespace WebApiSeyyedi.Services.ServiceInterfaces
{
    public interface IUserService
    {
        Task<User> MapToEntity(UserDTO user);
        Task<UserDTO> MapToDTO(User user);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> GetUser(int id);
        Task<UserDTO> AddUser(UserDTO user);
        Task RemoveUser(int userId);
        Task<UserDTO> UpdateUser(UserDTO user);
        Task<IEnumerable<UserDTO>> GetAllUserWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
