using Ninject.Modules;
using ShopMVC.DAL.Interfaces;
using ShopMVC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ShopMVC.Tests
{
    public class ShopTestsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().ToSelf();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}
