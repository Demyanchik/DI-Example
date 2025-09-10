using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject.Modules;
using DI.MyClasses;

using Ninject.Web.Common;

namespace DIExample.DI
{
    public class NIConfig1: NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary>().To<DLL1.Model>().InRequestScope();
        }
    }
}