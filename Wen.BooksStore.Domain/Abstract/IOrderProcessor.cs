using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.Domain.Abstract
{
    /// <summary>
    /// 订单处理
    /// </summary>
    public interface IOrderProcessor
    {
        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="contact"></param>
        void ProcessOrder(Cart cart, Contact contact);
    }
}
