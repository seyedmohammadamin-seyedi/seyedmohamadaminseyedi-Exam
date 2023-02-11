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
    public class BookDetailService : IBookDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BookDetailDTO> AddBookDetail(BookDetailDTO bookDetail)
        {
            var data = await MapToEntity(bookDetail);
            await _unitOfWork.BookDetailRepository.Add(data);
            await _unitOfWork.Commit();
            return bookDetail;
        }

        public async Task<IEnumerable<BookDetailDTO>> GetAllBookDetailWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDetailDTO> GetBookDetail(int id)
        {
            var data = await _unitOfWork.BookDetailRepository.GetById(id);
            return await MapToDTO(data);
        }

        public async Task<IEnumerable<BookDetailDTO>> GetBookDetailes()
        {
            IQueryable<BookDetail> datas = await _unitOfWork.BookDetailRepository.GetAll();
            return datas != null && datas.Any() ? datas.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<BookDetailDTO> MapToDTO(BookDetail bookDetail)
        {
            return new BookDetailDTO()
            {
                Id = bookDetail.Id,
                PublishDateTime = bookDetail.PublishDateTime,
                CountEdition = bookDetail.CountEdition,
                Description = bookDetail.Description,
                BookId = bookDetail.BookId,
            };
        }

        public async Task<BookDetail> MapToEntity(BookDetailDTO bookDetail)
        {
            return await Task.Run(() => new BookDetail()
            {
                Id = bookDetail.Id,
                PublishDateTime = bookDetail.PublishDateTime,
                CountEdition = bookDetail.CountEdition,
                Description = bookDetail.Description,
                BookId = bookDetail.BookId,
            });
        }

        public async Task RemoveBookDetail(int bookDetailId)
        {
            await _unitOfWork.BookDetailRepository.Delete(await _unitOfWork.BookDetailRepository.GetById(bookDetailId));
            await _unitOfWork.Commit();
        }

        public async Task<BookDetailDTO> UpdateBookDetail(BookDetailDTO bookDetail)
        {
            var data = await _unitOfWork.BookDetailRepository.Add(await MapToEntity(bookDetail));
            await _unitOfWork.Commit();
            return await MapToDTO(data);
        }
    }
}
