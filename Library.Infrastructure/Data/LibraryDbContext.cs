using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Infrastructure.Data
{
    public class LibraryDbContext :DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) :base(options) 
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
