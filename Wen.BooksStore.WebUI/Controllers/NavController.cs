using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wen.BooksStore.Domain.Abstract;

namespace Wen.BooksStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public NavController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public PartialViewResult Sidebar(string category = null)
        {
            ViewBag.CurrentCategory = category;

            var categories = _bookRepository.Books.Select(x => x.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}