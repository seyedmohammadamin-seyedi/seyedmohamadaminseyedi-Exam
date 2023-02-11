using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.DTO.DTOs;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            BookDTO book = await _bookService.GetBook(id.Value);

            return new JsonResult(book);
        }


        [HttpPost]
        public async Task<ActionResult> Create(BookDTO book)
        {

            if (ModelState.IsValid)
            {
                await _bookService.AddBook(book);
                return new JsonResult(_bookService.GetBooks());
            }
            return new JsonResult(book);
        }

        [HttpPut]
        public async Task<ActionResult> Edit( BookDTO book)
        {
            var databook = _bookService.GetBook(book.Id);
            if (databook != null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.UpdateBook(book);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return new JsonResult(book);
            }
            return new JsonResult(book);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            var data = await _bookService.GetBook(id.Value);
            return new JsonResult(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _bookService.RemoveBook(id);
            BookDTO book = new BookDTO();
            return new JsonResult(book);
        }
    }
}
