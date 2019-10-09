using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;

namespace LibrarySystem.Models
{
    public class LibrarySystemContext : DbContext
    {
        public LibrarySystemContext (DbContextOptions<LibrarySystemContext> options)
            : base(options)
        {
        }

        public DbSet<LibrarySystem.Models.Book> Book { get; set; }

        public DbSet<LibrarySystem.Models.Member> Member { get; set; }

        public DbSet<LibrarySystem.Models.BorrowedBook> BorrowedBook { get; set; }

        public DbSet<LibrarySystem.Models.BookCopy> BookCopy { get; set; }
    }
}
