using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.WebUI.Models
{
    /// <summary>
    /// 书籍详情视图模型
    /// </summary>
    public class BookDetailsViewModels : PagingInfo
    {
        public IEnumerable<Book> Books { get; set; }

        /// <summary>
        /// 当前分类
        /// </summary>
        public string CurrentCategory { get; set; }
    }
}