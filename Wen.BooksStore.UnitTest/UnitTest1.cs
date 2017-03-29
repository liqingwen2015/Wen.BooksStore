using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wen.BooksStore.Domain.Concrete;
using Wen.BooksStore.WebUI.HtmlHelpers;
using Wen.BooksStore.WebUI.Models;

namespace Wen.BooksStore.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BooksCountTest()
        {
            var bookRepository=new EfBookRepository();
            var books = bookRepository.Books;

            Assert.AreEqual(books.Count(),7);
        }

        [TestMethod]
        public void PageLinksTest()
        {
            HtmlHelper myHelper = null;
            var pagingInfo = new PagingInfo()
            {
                PageIndex = 1,
                TotalItems = 20,
                PageSize = 15
            };

            Func<int, string> func = x => "Page=" + x;
            var result = myHelper.PageLinks(pagingInfo, func);

            Assert.AreEqual(result.ToString(), @"<a class=""selected"" href=""Page=1"">1</a><a href=""Page=2"">2</a>");
        }
    }
}
