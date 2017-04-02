using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.BooksStore.Domain.Abstract;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.Domain.Concrete
{
    /// <summary>
    /// 书存储库
    /// </summary>
    public class EfBookRepository : IBookRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        /// <summary>
        /// 书模型集合
        /// </summary>
        public IQueryable<Book> Books => _context.Books;

        /// <summary>
        /// 保存书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int SaveBook(Book book)
        {
            if (book.Id == 0)
            {
                _context.Books.Add(book);
            }
            else
            {
                var model = _context.Books.Find(book.Id);

                if (model==null)
                {
                    return 0;
                }

                model.Category = book.Category;
                model.Description = book.Description;
                model.Name = book.Name;
                model.Price = book.Price;
            }

            return _context.SaveChanges();
        }

        /// <summary>
        /// 删除书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book DeleteBook(int id)
        {
            var model = _context.Books.Find(id);

            if (model == null)
            {
                return null;
            }

            _context.Books.Remove(model);
            _context.SaveChanges();

            return model;
        }
    }
}
