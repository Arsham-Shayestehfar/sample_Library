using Domain.Entities;
using Domain.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;
        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<Author> AddAsync(Author author)
        {
               _context.Authors.Add(author);
            await  _context.SaveChangesAsync();
            return author;
                    
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var author =await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (author == null)
               return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;    


        }

        public async Task<IEnumerable<Author>> GetAllAsync() =>
        
          await  _context.Authors.Include(b=>b.Books).ToListAsync();

        

        public async Task<Author?> GetByIdAsync(int id) =>
           await _context.Authors.Include(b=>b.Books).FirstOrDefaultAsync(s=>s.Id == id);
        

        public async Task<bool> UpdateAsync(Author author)
        {
          var exist =await _context.Authors.Include(b=>b.Books).FirstOrDefaultAsync(s=>s.Id==author.Id);
          if(exist == null)
            
           return false;

            exist.Name = author.Name;
            exist.Bio = author.Bio;
            exist.DateOfBirth = author.DateOfBirth;
             await _context.SaveChangesAsync();
            return true;


        }
    }
}
