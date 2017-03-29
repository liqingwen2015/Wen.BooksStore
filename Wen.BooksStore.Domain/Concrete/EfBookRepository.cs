using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.BooksStore.Domain.Abstract;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.Domain.Concrete
{
    public class EfBookRepository : IBookRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IQueryable<Book> Books => _context.Books;
    }
}
