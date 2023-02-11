using Microsoft.AspNetCore.Mvc;
using WebApiSeyyedi.DTO.DTOs;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            CategoryDTO category = await _categoryService.GetCategory(id.Value);

            return new JsonResult(category);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryDTO category)
        {

            if (ModelState.IsValid)
            {
                await _categoryService.AddCategory(category);
                return new JsonResult(_categoryService.GetCategories());
            }
            return new JsonResult(category);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(CategoryDTO category)
        {
            var data = _categoryService.GetCategory(category.Id);
            if (data == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.UpdateCategory(category);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return new JsonResult(category);
            }
            return new JsonResult(category);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            var data = await _categoryService.GetCategory(id.Value);
            return new JsonResult(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.RemoveCategory(id);
            CategoryDTO category = new CategoryDTO();
            return new JsonResult(category);
        }
    }
}
