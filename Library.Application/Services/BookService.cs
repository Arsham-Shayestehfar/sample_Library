using Domain.Entities;
using Domain.Interfaces;
using Library.Application.Dtos;
using Library.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _book;
        public BookService(IBookRepository book)
        {
            _book = book;
        }
        public async Task<BookDto> AddAsync(BookDto bookDto)
        {
            var book = new Book
            {
                
                Title = bookDto.Title,
                Description = bookDto.Description,
                AuthorId = bookDto.AuthorId,
                PublishDate = bookDto.PublishDate,
            };
          var created = await _book.AddAsync(book);
            bookDto.Id = created.Id;
            return bookDto;
        }

        public async Task<bool> DeleteAsync(int id) =>
            await _book.DeleteAsync(id);
        

        public async Task<IEnumerable<BookDto>> GetAllAsync()
        {
            var books=  await _book.GetAllAsync();
            return books.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.AuthorId,
                PublishDate = book.PublishDate,

            });
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _book.GetByIdAsync(id);
            if (book == null)
                return null;
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = book.AuthorId,
                PublishDate = book.PublishDate,

            };
        }

        public async Task<bool> UpdateAsync(BookDto bookDto)
        {
            var book = new Book
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Description = bookDto.Description,
                AuthorId = bookDto.AuthorId,
                PublishDate = bookDto.PublishDate,

            };
            return await _book.UpdateAsync(book);
        }
    }
}
