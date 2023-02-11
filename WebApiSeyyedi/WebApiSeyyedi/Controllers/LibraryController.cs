using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSeyyedi.DTO.DTOs;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {

        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            LibraryDTO library = await _libraryService.GetLibrary(id.Value);

            return new JsonResult(library);
        }

        

        [HttpPost]
        public async Task<ActionResult> Create([Bind("Id,Name,Address,PhoneNumber,EmailAddress,LibraryNumber")] LibraryDTO library)
        {

            if (ModelState.IsValid)
            {
                await _libraryService.AddLibrary(library);
                return new JsonResult(_libraryService.GetLibraries());
            }
            return new JsonResult(library);
        }

        

        [HttpPut]
        public async Task<ActionResult> Edit(LibraryDTO library)
        {
            var amin = _libraryService.GetLibrary(library.Id);
            if (amin == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _libraryService.UpdateLibrary(library);
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return new JsonResult(library);
            }
            return new JsonResult(library);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            var data = await _libraryService.GetLibrary(id.Value);
            return new JsonResult(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _libraryService.RemoveLibrary(id);
            LibraryDTO library = new LibraryDTO();
            return new JsonResult(library);
        }


        //[HttpGet]
        //public async Task<IActionResult> GetAllLibraryWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        //{

        //    ViewBag.CurrentSort = sortOrder;
        //    ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
        //    ViewBag.CurrentFilter = searchString;



        //    var datas = _libraryService.GetAllLibraryWithPagination(sortOrder, currentFilter, searchString, page, pageSize);
        //    return new JsonResult(nameof(Index), datas);
        //}
    }
}
