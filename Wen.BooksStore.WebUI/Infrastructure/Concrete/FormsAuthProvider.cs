using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Wen.BooksStore.WebUI.Infrastructure.Abstract;

namespace Wen.BooksStore.WebUI.Infrastructure.Concrete
{
    /// <summary>
    /// 表单认证提供者
    /// </summary>
    public class FormsAuthProvider:IAuthProvider
    {
        /// <summary>
        /// 认证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Auth(string userName, string password)
        {
            var result = FormsAuthentication.Authenticate(userName, password);

            if (result)
            {
                //设置认证 Cookie
                FormsAuthentication.SetAuthCookie(userName, false);
            }

            return result;
        }
    }
}