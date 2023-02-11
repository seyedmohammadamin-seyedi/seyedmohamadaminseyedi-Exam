using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSeyyedi.DTO.DTOs;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            UserDTO user = await _userService.GetUser(id.Value);

            return new JsonResult(user);
        }

        

        [HttpPost]
        public async Task<ActionResult> Create(UserDTO user)
        {

            if (ModelState.IsValid)
            {
                await _userService.AddUser(user);
                return new JsonResult(_userService.GetUsers());
            }
            return new JsonResult(user);
        }

       

        [HttpPut]
        public async Task<ActionResult> Edit(UserDTO user)
        {
            var dataa = _userService.GetUser(user.Id);
            if (dataa == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.UpdateUser(user);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return new JsonResult(user);
            }
            return new JsonResult(user);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            var data = await _userService.GetUser(id.Value);
            return new JsonResult(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _userService.RemoveUser(id);
            UserDTO user = new UserDTO();
            return new JsonResult(user);
        }
    }
}
