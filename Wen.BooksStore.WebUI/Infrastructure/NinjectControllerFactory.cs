using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Wen.BooksStore.Domain.Abstract;
using Wen.BooksStore.Domain.Concrete;

namespace Wen.BooksStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController) _kernel.Get(controllerType);
        }

        /// <summary>
        /// 添加绑定
        /// </summary>
        private void AddBindings()
        {
            _kernel.Bind<IBookRepository>().To<EfBookRepository>();
        }
    }
}