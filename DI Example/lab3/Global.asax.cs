using Ninject;
using Ninject.Web.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            using (StreamWriter sw = new StreamWriter(@"D:\Projects\DI example\log.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine();
            }

            var kernel = new StandardKernel(new DIExample.DI.NIConfig1());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
