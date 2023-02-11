using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSeyyedi.DTO.DTOs;
using WebApiSeyyedi.Services.ServiceClasses;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookDetailController : ControllerBase
    {
        private readonly IBookDetailService _bookDetailService;
        public BookDetailController(IBookDetailService bookDetailService)
        {
            
            _bookDetailService = bookDetailService;
        }

        

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            BookDetailDTO bookDetail = await _bookDetailService.GetBookDetail(id.Value);

            return new JsonResult(bookDetail);
        }

       

        [HttpPost]
        public async Task<ActionResult> Create(BookDetailDTO bookDetail)
        {

            if (ModelState.IsValid)
            {
                await _bookDetailService.AddBookDetail(bookDetail);
                return new JsonResult(_bookDetailService.GetBookDetailes());
            }
            return new JsonResult(bookDetail);
        }

        

        [HttpPut]
        public async Task<ActionResult> Edit( BookDetailDTO bookDetail)
        {
            var databd = _bookDetailService.GetBookDetail(bookDetail.Id);
            if (databd == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookDetailService.UpdateBookDetail(bookDetail);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return new JsonResult(bookDetail);
            }
            return new JsonResult(bookDetail);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            var data = await _bookDetailService.GetBookDetail(id.Value);
            return new JsonResult(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _bookDetailService.RemoveBookDetail(id);
            BookDetailDTO bookDetail = new BookDetailDTO();
            return new JsonResult(bookDetail);
        }
    }
}
