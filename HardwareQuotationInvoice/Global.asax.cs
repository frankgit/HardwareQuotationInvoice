using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HardwareQuotationInvoice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //注册StructureMap
            var container = new Container();
            StructureMapBootrstrapper.Bootstrap(container);

            //通过StructureMap返回Controller实例，通过构造器注入
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory(container));
        }
    }
}
