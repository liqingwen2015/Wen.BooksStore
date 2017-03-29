using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wen.BooksStore.WebUI.Models
{
    /// <summary>
    /// 分页信息
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}