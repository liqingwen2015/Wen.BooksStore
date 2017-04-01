using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.BooksStore.Domain.Entities
{
    /// <summary>
    /// 购物车项
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// 书
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
    }
}
