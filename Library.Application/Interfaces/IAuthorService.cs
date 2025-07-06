using Library.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto?> GetByIdAsync(int id);
        Task<AuthorDto> AddAsync(AuthorDto authorDto);
        Task<bool> UpdateAsync(AuthorDto authorDto);

        Task<bool> DeleteAsync(int id);
    }
}
