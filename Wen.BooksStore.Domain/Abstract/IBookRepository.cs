using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.Domain.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
