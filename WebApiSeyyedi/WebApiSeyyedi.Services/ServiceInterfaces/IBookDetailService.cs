using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiSeyyedi.Data.Models;
using WebApiSeyyedi.DTO.DTOs;

namespace WebApiSeyyedi.Services.ServiceInterfaces
{
    public interface IBookDetailService
    {
        Task<BookDetail> MapToEntity(BookDetailDTO bookDetail);
        Task<BookDetailDTO> MapToDTO(BookDetail bookDetail );
        Task<IEnumerable<BookDetailDTO>> GetBookDetailes();
        Task<BookDetailDTO> GetBookDetail(int id);
        Task<BookDetailDTO> AddBookDetail(BookDetailDTO bookDetail);
        Task RemoveBookDetail(int bookDetailId);
        Task<BookDetailDTO> UpdateBookDetail(BookDetailDTO bookDetail);
        Task<IEnumerable<BookDetailDTO>> GetAllBookDetailWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
