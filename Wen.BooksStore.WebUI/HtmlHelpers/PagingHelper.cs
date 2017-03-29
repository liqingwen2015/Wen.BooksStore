using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Wen.BooksStore.WebUI.Models;

namespace Wen.BooksStore.WebUI.HtmlHelpers
{
    public static class PagingHelper
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pagingInfo"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper helper, PagingInfo pagingInfo, Func<int, string> func)
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= pagingInfo.TotalPages; i++)
            {
                //创建 <a> 标签
                var tagBuilder = new TagBuilder("a");
                //添加特性
                tagBuilder.MergeAttribute("href", func(i));
                //添加值
                tagBuilder.InnerHtml = i.ToString();

                if (i == pagingInfo.PageIndex)
                {
                    tagBuilder.AddCssClass("selected");
                }

                sb.Append(tagBuilder);
            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}