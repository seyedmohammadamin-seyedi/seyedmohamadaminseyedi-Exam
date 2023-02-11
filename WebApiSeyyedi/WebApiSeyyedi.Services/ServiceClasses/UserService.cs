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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UserDTO> AddUser(UserDTO user)
        {
            var data = await MapToEntity(user);
            await _unitOfWork.UserRepository.Add(data);
            await _unitOfWork.Commit();
            return user;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUserWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var users = await _unitOfWork.UserRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.Name);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }
            pageSize = pageSize.HasValue ? pageSize : 0;
            int pageNumber = (page ?? 1);
            users = users.Skip(pageSize.Value * pageNumber).Take(pageSize.Value);
            return users != null && users.Any() ? users.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var data = await _unitOfWork.UserRepository.GetById(id);
            return await MapToDTO(data);
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            IQueryable<User> datas = await _unitOfWork.UserRepository.GetAll();
            return datas != null && datas.Any() ? datas.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<UserDTO> MapToDTO(User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                UserRoleId = user.UserRoleId
            };
        }

        public async Task<User> MapToEntity(UserDTO user)
        {
            return await Task.Run(() => new User()
            {
                Id = user.Id,
                Name = user.Name,
                UserRoleId = user.UserRoleId
            });
        }

        public async Task RemoveUser(int userId)
        {
            await _unitOfWork.UserRepository.Delete(await _unitOfWork.UserRepository.GetById(userId));
            await _unitOfWork.Commit();
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            var data = await _unitOfWork.UserRepository.Add(await MapToEntity(user));
            await _unitOfWork.Commit();
            return await MapToDTO(data);
        }
    }
}
