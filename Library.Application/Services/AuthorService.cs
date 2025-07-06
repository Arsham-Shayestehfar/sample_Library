using Domain.Entities;
using Domain.Interfaces;
using Library.Application.Dtos;
using Library.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _author;
        public AuthorService(IAuthorRepository authorRepository)
        {
                
        _author = authorRepository;
        }
        public async Task<AuthorDto> AddAsync(AuthorDto authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name,
                Bio = authorDto.Bio,
                DateOfBirth = authorDto.DateOfBirth,
            };
            var created =await _author.AddAsync(author);
            authorDto.Id = created.Id;
            return authorDto;
        }

        public async Task<bool> DeleteAsync(int id) =>
        
          await  _author.DeleteAsync(id);
        

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authors = await _author.GetAllAsync();
            return authors.Select(s=> new AuthorDto
            {
                Id = s.Id,
                Name = s.Name,
                Bio = s.Bio,
                DateOfBirth = s.DateOfBirth,

            });
        }

        public async Task<AuthorDto?> GetByIdAsync(int id)
        {
             var author = await _author.GetByIdAsync(id);
            if (author == null)
                return null;
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio,
                DateOfBirth = author.DateOfBirth,

            };
        }



        public async Task<bool> UpdateAsync(AuthorDto authorDto)
        {
            var author = new Author
            {
                Id = authorDto.Id,
                Name = authorDto.Name,
                Bio = authorDto.Bio,
                DateOfBirth = authorDto.DateOfBirth,

            };
           return await _author.UpdateAsync(author);
        }
            
        
    }
}
