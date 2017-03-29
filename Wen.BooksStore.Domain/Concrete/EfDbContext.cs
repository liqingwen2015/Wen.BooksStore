using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
