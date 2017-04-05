using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wen.BooksStore.WebUI.Infrastructure.Abstract;
using Wen.BooksStore.WebUI.Models;

namespace Wen.BooksStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public AccountController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(new LoginViewModel());
            }

            var result = _authProvider.Auth(model.UserName, model.Password);
            if (result) return RedirectToAction("Index", "Admin");

            ModelState.AddModelError("", "账号或用户名有误");
            return View(new LoginViewModel());
        }
    }
}