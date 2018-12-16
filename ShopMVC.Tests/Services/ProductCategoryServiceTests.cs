using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using ShopMVC.DAL.Interfaces;
using System.Data.Entity;
using ShopMVC.DAL;

namespace ShopMVC.Tests.Services
{
    /// <summary>
    /// Summary description for ProductCategoryServiceTests
    /// </summary>
    //[TestFixture]
    //public class ProductCategoryServiceTests
    //{
    //    //[Test]
    //    //public void GetProductCategorySuccess()
    //    //{
    //    //    //Arrange
    //    //    var testObject = new ProductCategory() { Name = "motorbike" };
    //    //    //var dbContext = new Mock<DbContext>();
    //    //    //Guid guid = Guid.NewGuid();
    //    //    //var category = new ProductCategory() { Name = "Motorbike", rowguid = guid };


    //    //    var repo = new Mock<IRepository<ProductCategory>>(It.IsAny<DbContext>());
    //    //    repo.Setup(x => x.Get(It.IsAny<int>())).Returns(testObject);

    //    //    var sut = new ProductCategories(repo.Object);
    //    //}
    //}
}
