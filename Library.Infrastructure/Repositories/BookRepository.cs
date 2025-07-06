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
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<Book> AddAsync(Book book)
        {
           _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var book=await _context.Books.FirstOrDefaultAsync(s=>s.Id == id);
            if (book == null)
                return false;
             _context.Books.Remove(book);
           await  _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<IEnumerable<Book>> GetAllAsync() =>
          await  _context.Books.Include(a=>a.Author).ToListAsync();
        

        public async Task<Book?> GetByIdAsync(int id) =>
            await _context.Books.Include(a=>a.Author).FirstOrDefaultAsync(a=>a.Id == id);
       

        public async Task<bool> UpdateAsync(Book book)
        {
           var exist =await _context.Books.FirstOrDefaultAsync(s=>s.Id==book.Id);
            if (exist == null)
                return false;
            exist.Title = book.Title;
            exist.PublishDate = book.PublishDate;
            exist.Description = book.Description;
            exist.AuthorId = book.Id;

            await _context.SaveChangesAsync();
            return true;
             
        }
    }
}
