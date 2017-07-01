using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwareQuotationInvoice
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        IContainer _container;
        public StructureMapControllerFactory(IContainer container)
        {
            _container = container;
        }
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, System.Type controllerType)
        {
            if (controllerType != null)
            {
                Controller c = _container.GetInstance(controllerType) as Controller;

                //当返回一个错误页面，View一级异常会被触发
                c.ActionInvoker = new ErrorHandlingActionInvoker(new HandleErrorAttribute());
                return c;
            }
            else
                return null;
        }
    }

    public class ErrorHandlingActionInvoker : ControllerActionInvoker
    {
        private readonly IExceptionFilter filter;

        public ErrorHandlingActionInvoker(IExceptionFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException("Exception filter is missing");

            this.filter = filter;
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filterInfo = base.GetFilters(controllerContext, actionDescriptor);
            filterInfo.ExceptionFilters.Add(this.filter);
            return filterInfo;
        }
    }
}