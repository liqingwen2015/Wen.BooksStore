using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wen.BooksStore.Domain.Abstract;
using Wen.BooksStore.Domain.Entities;

namespace Wen.BooksStore.WebUI.Controllers
{
    /// <summary>
    /// 后台管理控制器
    /// </summary>
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public AdminController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_bookRepository.Books);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Book());
            }

            var model = _bookRepository.Books.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            _bookRepository.SaveBook(book);
            TempData["msg"] = $"{book.Name} 保存成功！";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var book = _bookRepository.DeleteBook(id);
            TempData["msg"] = $"{book.Name} 删除成功！";
            return RedirectToAction("Index");
        }
    }
}