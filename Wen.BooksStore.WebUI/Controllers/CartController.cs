using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wen.BooksStore.Domain.Abstract;
using Wen.BooksStore.Domain.Entities;
using Wen.BooksStore.WebUI.Models;

namespace Wen.BooksStore.WebUI.Controllers
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class CartController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IOrderProcessor _orderProcessor;

        public CartController(IBookRepository bookRepository, IOrderProcessor orderProcessor)
        {
            _bookRepository = bookRepository;
            _orderProcessor = orderProcessor;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel()
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(int id, string returnUrl)
        {
            var book = _bookRepository.Books.FirstOrDefault(x => x.Id == id);

            if (book != null)
            {
                GetCart().AddBook(book, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// 从购物车移除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFromCart(int id, string returnUrl)
        {
            var book = _bookRepository.Books.FirstOrDefault(x => x.Id == id);

            if (book != null)
            {
                GetCart().RemoveBook(book);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult Clear(string returnUrl)
        {
            GetCart().Clear();
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// 获取购物车
        /// </summary>
        /// <returns></returns>
        private Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart != null) return cart;

            cart = new Cart();
            Session["Cart"] = cart;

            return cart;
        }

        /// <summary>
        /// 摘要
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <returns></returns>
        public ViewResult Checkout()
        {
            return View(new Contact());
        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Checkout(Contact contact)
        {
            if (!ModelState.IsValid)
                return View(contact);

            var cart = GetCart();
            _orderProcessor.ProcessOrder(cart, contact);
            cart.Clear();
            return View("Thanks");
        }
    }
}