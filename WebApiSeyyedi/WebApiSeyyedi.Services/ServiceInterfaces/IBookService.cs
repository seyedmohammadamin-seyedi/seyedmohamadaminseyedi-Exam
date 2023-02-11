using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.DTO.DTOs;

namespace WebApiSeyyedi.Services.ServiceInterfaces
{
    public interface IBookService
    {
        Task<Book> MapToEntity(BookDTO book);
        Task<BookDTO> MapToDTO(Book book);
        Task<IEnumerable<BookDTO>> GetBooks();
        Task<BookDTO> GetBook(int id);
        Task<BookDTO> AddBook(BookDTO book);
        Task RemoveBook(int bookId);
        Task<BookDTO> UpdateBook(BookDTO book);
        Task<IEnumerable<BookDTO>> GetAllBookWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
