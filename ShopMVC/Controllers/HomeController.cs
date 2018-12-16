using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMVC.DAL;
using ShopMVC.DAL.Repositories;
using ShopMVC.DAL.Interfaces;

namespace ShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<ProductCategory> _repositoryProductCategory;

        public HomeController(IRepository<ProductCategory> repositoryProductCategory)
        {
            _repositoryProductCategory = repositoryProductCategory;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var product = _repositoryProductCategory.Get(1);
            if(product != null)
            {
                ViewBag.Cat = product.Name;
            }
            else
            {
                ViewBag.Cat = "object is null";
            }


            //using (var context = new AdventureWorks2016Entities())
            //{
            //    //var lst = context.ProductCategories.ToList();

            //    var repo = new Repository<ProductCategory>(context);
            //    var obj = repo.Get(1);

            //    int x = 0;
            //}

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}