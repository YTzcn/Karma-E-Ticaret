using System.Collections.Concurrent;
using Karma.Business.Concrete;
using Karma.DataAccess;
using Moq;
using Karma.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation;
using Assert = NUnit.Framework.Assert;

namespace Karma.Business.Test
{
    public class ProductManagerTest
    {
        //[ExpectedException(typeof(ValidationException))]
        [Test]
        public void Product_Validation_Check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);
            productManager.Add(new Product {ProductName="Sanane LA" });
        }
    }
}