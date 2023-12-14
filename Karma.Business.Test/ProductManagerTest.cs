using System.Collections.Concurrent;
using Karma.Business.Concrete;
using Karma.DataAccess;
using Moq;
using Karma.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentValidation;
using Assert = NUnit.Framework.Assert;
using Karma.Entities;

namespace Karma.Business.Test
{
    public class ProductManagerTest
    {
        [Test]
        public void Product_Validation_Check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            Assert.Throws<ValidationException>(() => productManager.Add(new Product { ProductId = 12, ProductName = "Xiaomi", Price = 20, Description = "asd", SubDescription = "ds", Active = true, Brand = new Brand { BrandId = 3 }, Category = new Category { CategoryId = 1 }, Color = "Sarý", UnitInStock = 30, Spesifications = new Spesification() })); ;
        }
    }
}