using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.BooksStore.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        /// <summary>
        /// 认证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Auth(string userName, string password);
    }
}
