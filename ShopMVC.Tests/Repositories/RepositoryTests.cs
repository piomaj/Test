using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using System.Data.Entity;
using ShopMVC.DAL.Repositories;
using System.Linq;
using System;

namespace ShopMVC.Tests.Repositories
{
    /// <summary>
    /// Summary description for RepositoryTests
    /// </summary>
    [TestFixture]
    public class Repository_Tests
    {
        //[Test]
        //public void Returned_Null_Entity_For_Invalid_Id()
        //{
        //    //Arrange
        //    var negativeId = -1;
        //    TestClass nullTestClass = null;
        //    var testObject = new TestClass();
        //    var dbContext = new Mock<DbContext>();
        //    var dbSet = new Mock<DbSet<TestClass>>();
        //    var sut = new Repository<TestClass>(dbContext.Object);

        //    dbContext.Setup(x => x.Set<TestClass>()).Returns(dbSet.Object);
        //    dbSet.Setup(x => x.Find(negativeId)).Returns((TestClass)null);

        //    //Act
        //    var result = sut.Get(negativeId);

        //    //Assert
        //    Assert.AreEqual(result, (TestClass)null);
        //}

        [Test]
        public void Passing_Null_DbContext()
        {
            Assert.Throws<ArgumentNullException>(() => new Repository<TestClass>(null));
        }
        
        [Test]
        public void Returned_Entity_Was_Returned_Successfully()
        {
            //Arrange
            var testObject = new TestClass()
            {
                Id = 1
            };
            var dbContext = new Mock<DbContext>();
            var dbSet = new Mock<DbSet<TestClass>>();

            dbContext.Setup(x => x.Set<TestClass>()).Returns(dbSet.Object);
            dbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(testObject);
            var sut = new Repository<TestClass>(dbContext.Object);

            //Act
            var result = sut.Get(testObject.Id);

            //Assert
            dbContext.Verify(x => x.Set<TestClass>());
            dbSet.Verify(x => x.Find(It.IsAny<int>()));
            Assert.AreEqual(result, testObject);
        }

        [Test]
        public void Returned_Multiple_Number_Of_Records()
        {
            //Arrange
            var testList = new List<TestClass>()
            {
                {new TestClass() { Id = 1 } },
                {new TestClass() { Id = 2 } }
            }.AsQueryable();

            var dbSet = new Mock<DbSet<TestClass>>();
            var dbContext = new Mock<DbContext>();
          
            dbSet.As<IQueryable<TestClass>>().Setup(x => x.Provider).Returns(testList.Provider);
            dbSet.As<IQueryable<TestClass>>().Setup(x => x.Expression).Returns(testList.Expression);
            dbSet.As<IQueryable<TestClass>>().Setup(x => x.ElementType).Returns(testList.ElementType);
            dbSet.As<IQueryable<TestClass>>().Setup(x => x.GetEnumerator()).Returns(testList.GetEnumerator);
            dbContext.Setup(x => x.Set<TestClass>()).Returns(dbSet.Object).Verifiable();
            
            var sut = new Repository<TestClass>(dbContext.Object);

            //Act
            var result = sut.GetAll();

            //Assert
            dbSet.Verify();
            dbContext.Verify();
            NUnit.Framework.Assert.AreEqual(result.Count, testList.Count());
        }
    }    
}
