using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.BooksStore.Domain.Entities
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class Cart
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        /// <summary>
        /// 获取购物车的所有项目
        /// </summary>
        public IList<CartItem> GetCartItems => _cartItems;

        /// <summary>
        /// 添加书模型
        /// </summary>
        /// <param name="book"></param>
        /// <param name="quantity"></param>
        public void AddBook(Book book, int quantity)
        {
            if (_cartItems.Count == 0)
            {
                _cartItems.Add(new CartItem() { Book = book, Quantity = quantity });
                return;
            }

            var model = _cartItems.FirstOrDefault(x => x.Book.Id == book.Id);
            if (model == null)
            {
                _cartItems.Add(new CartItem() { Book = book, Quantity = quantity });
                return;
            }

            model.Quantity += quantity;
        }

        /// <summary>
        /// 移除书模型
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            var model = _cartItems.FirstOrDefault(x => x.Book.Id == book.Id);
            if (model == null)
            {
                return;
            }

            _cartItems.RemoveAll(x => x.Book.Id == book.Id);
        }

        /// <summary>
        /// 清空购物车
        /// </summary>
        public void Clear()
        {
            _cartItems.Clear();
        }

        /// <summary>
        /// 统计总额
        /// </summary>
        /// <returns></returns>
        public decimal ComputeTotalValue()
        {
            return _cartItems.Sum(x => x.Book.Price * x.Quantity);
        }
    }
}
