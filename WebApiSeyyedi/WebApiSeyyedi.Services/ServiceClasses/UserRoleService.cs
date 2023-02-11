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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UserRoleDTO> AddUserRole(UserRoleDTO userRole)
        {
            var data = await MapToEntity(userRole);
            await _unitOfWork.UserRoleRepository.Add(data);
            await _unitOfWork.Commit();
            return userRole;
        }

        public async Task<IEnumerable<UserRoleDTO>> GetAllUserRoleWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var userRoles = await _unitOfWork.UserRoleRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                userRoles = userRoles.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    userRoles = userRoles.OrderByDescending(s => s.Name);
                    break;
                default:
                    userRoles = userRoles.OrderBy(s => s.Name);
                    break;
            }
            pageSize = pageSize.HasValue ? pageSize : 0;
            int pageNumber = (page ?? 1);
            userRoles = userRoles.Skip(pageSize.Value * pageNumber).Take(pageSize.Value);
            return userRoles != null && userRoles.Any() ? userRoles.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<UserRoleDTO> GetUserRole(int id)
        {
            var data = await _unitOfWork.UserRoleRepository.GetById(id);
            return await MapToDTO(data);
        }

        public async Task<IEnumerable<UserRoleDTO>> GetUserRoles()
        {
            IQueryable<UserRole> datas = await _unitOfWork.UserRoleRepository.GetAll();
            return datas != null && datas.Any() ? datas.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<UserRoleDTO> MapToDTO(UserRole userRole)
        {
            return new UserRoleDTO()
            {
                Id = userRole.Id,
                Name = userRole.Name
            };
        }

        public async Task<UserRole> MapToEntity(UserRoleDTO userRole)
        {
            return await Task.Run(() => new UserRole()
            {
                Id = userRole.Id,
                Name = userRole.Name
            });
        }

        public async Task RemoveUserRole(int userRoleId)
        {
            await _unitOfWork.UserRoleRepository.Delete(await _unitOfWork.UserRoleRepository.GetById(userRoleId));
            await _unitOfWork.Commit();
        }

        public async Task<UserRoleDTO> UpdateUserRole(UserRoleDTO userRole)
        {
            var data = await _unitOfWork.UserRoleRepository.Add(await MapToEntity(userRole));
            await _unitOfWork.Commit();
            return await MapToDTO(data);
        }
    }
}
