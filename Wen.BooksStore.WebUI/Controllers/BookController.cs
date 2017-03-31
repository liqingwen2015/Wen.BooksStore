#region

using System.Linq;
using System.Web.Mvc;
using Wen.BooksStore.Domain.Abstract;
using Wen.BooksStore.WebUI.Models;

#endregion

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
        /// <param name="category">分类</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public ActionResult Details(string category, int pageIndex = 1)
        {
            var model = new BookDetailsViewModels
            {
                Books =
                    _bookRepository.Books.Where(x => category == null || x.Category == category)
                        .OrderBy(x => x.Id)
                        .Skip((pageIndex - 1) * PageSize)
                        .Take(PageSize),
                CurrentCategory = category,
                PageSize = PageSize,
                PageIndex = pageIndex,
                TotalItems = _bookRepository.Books.Count(x => category == null || x.Category == category)
            };

            return View(model);
        }
    }
}