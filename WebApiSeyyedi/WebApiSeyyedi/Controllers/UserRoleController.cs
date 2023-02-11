using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSeyyedi.DTO.DTOs;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            UserRoleDTO userRole = await _userRoleService.GetUserRole(id.Value);

            return new JsonResult(userRole);
        }

        

        [HttpPost]
        public async Task<ActionResult> Create(UserRoleDTO userRole)
        {

            if (ModelState.IsValid)
            {
                await _userRoleService.AddUserRole(userRole);
                return new JsonResult(_userRoleService.GetUserRoles());
            }
            return new JsonResult(userRole);
        }

       

        [HttpPut]
        public async Task<ActionResult> Edit(UserRoleDTO userRole)
        {
            var d = _userRoleService.GetUserRole(userRole.Id);
            if (d == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userRoleService.UpdateUserRole(userRole);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return new JsonResult(userRole);
            }
            return new JsonResult(userRole);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            var data = await _userRoleService.GetUserRole(id.Value);
            return new JsonResult(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _userRoleService.RemoveUserRole(id);
            UserRoleDTO userRole = new UserRoleDTO();
            return new JsonResult(userRole);
        }
    }
}
