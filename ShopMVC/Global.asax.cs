using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using System.Reflection;
using ShopMVC.DAL.Repositories;
using ShopMVC.DAL.Interfaces;
using System.Data.Entity;
using Ninject.Web.Common;
using ShopMVC.DAL;

namespace ShopMVC
{
    public class MvcApplication : NinjectHttpApplication
    {
        //protected void Application_Start()
        //{
        //    //AreaRegistration.RegisterAllAreas();
        //    //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    //RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    //BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<DbContext>().ToSelf();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope().WithConstructorArgument("dbContext", new AdventureWorks2016Entities());
            return kernel;
        }
    }
}
