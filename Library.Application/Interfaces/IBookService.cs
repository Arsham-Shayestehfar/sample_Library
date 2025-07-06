using Library.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task<BookDto> AddAsync(BookDto bookDto);
        Task<bool> UpdateAsync(BookDto bookDto);

        Task<bool> DeleteAsync(int id);
    }
}
