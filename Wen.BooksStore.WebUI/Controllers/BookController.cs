using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wen.BooksStore.Domain.Abstract;
using Wen.BooksStore.WebUI.Models;

namespace Wen.BooksStore.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public int PageSize = 5;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Details(int pageIndex = 1)
        {
            var model = new BookDetailsViewModels()
            {
                Books = _bookRepository.Books.OrderBy(x => x.Id).Skip((pageIndex - 1) * PageSize).Take(PageSize),
                PageSize = PageSize,
                PageIndex = pageIndex,
                TotalItems = _bookRepository.Books.Count()
            };

            return View(model);
        }
    }
}