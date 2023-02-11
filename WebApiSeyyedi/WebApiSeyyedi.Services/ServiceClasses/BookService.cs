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
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BookDTO> AddBook(BookDTO book)
        {
            var data = await MapToEntity(book);
            await _unitOfWork.BookRepository.Add(data);
            await _unitOfWork.Commit();
            return book;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBookWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var books = await _unitOfWork.BookRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    books = books.OrderByDescending(s => s.Name);
                    break;
                default:
                    books = books.OrderBy(s => s.Name);
                    break;
            }
            pageSize = pageSize.HasValue ? pageSize : 0;
            int pageNumber = (page ?? 1);
            books = books.Skip(pageSize.Value * pageNumber).Take(pageSize.Value);
            return books != null && books.Any() ? books.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<BookDTO> GetBook(int id)
        {
            var data = await _unitOfWork.BookRepository.GetById(id);
            return await MapToDTO(data);
        }

        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            IQueryable<Book> datas = await _unitOfWork.BookRepository.GetAll();
            return datas != null && datas.Any() ? datas.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<BookDTO> MapToDTO(Book book)
        {
            return new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                AuthorName = book.AuthorName,
                Price = book.Price,
                LibraryId = book.LibraryId,
                CategoryId = book.CategoryId
            };
        }

        public async Task<Book> MapToEntity(BookDTO book)
        {
            return await Task.Run(() => new Book()
            {
                Id = book.Id,
                Name = book.Name,
                AuthorName = book.AuthorName,
                Price = book.Price,
                LibraryId = book.LibraryId,
                CategoryId = book.CategoryId
            });
        }

        public async Task RemoveBook(int bookId)
        {
            await _unitOfWork.BookRepository.Delete(await _unitOfWork.BookRepository.GetById(bookId));
            await _unitOfWork.Commit();
        }

        public async Task<BookDTO> UpdateBook(BookDTO book)
        {
            var data = await _unitOfWork.BookRepository.Add(await MapToEntity(book));
            await _unitOfWork.Commit();
            return await MapToDTO(data);
        }
    }
}
