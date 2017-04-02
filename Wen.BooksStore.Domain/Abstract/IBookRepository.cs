using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.Domain.Abstract
{
    /// <summary>
    /// 书存储库接口
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// 书模型集合
        /// </summary>
        IQueryable<Book> Books { get; }

        /// <summary>
        /// 保存书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        int SaveBook(Book book);

        /// <summary>
        /// 删除书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Book DeleteBook(int id);
    }
}
