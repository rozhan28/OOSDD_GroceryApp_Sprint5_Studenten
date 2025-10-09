using NUnit.Framework;
using Moq;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Services;
using Grocery.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace TestCore
{
    [TestFixture]
    public class ProductCategoriesTests
    {
        private Mock<IProductRepository> _mockProductRepo;
        private Mock<IProductCategoryRepository> _mockProductCategoryRepo;
        private ProductCategoryService _service;

        [SetUp]
        public void Setup()
        {
            _mockProductRepo = new Mock<IProductRepository>();
            _mockProductCategoryRepo = new Mock<IProductCategoryRepository>();

            var products = new List<Product>
            {
                new Product(1, "Melk", 10, 1.5m),
                new Product(2, "Brood", 5, 2.0m),
                new Product(3, "Kaas", 8, 3.5m)
            };

            var productCategories = new List<ProductCategory>
            {
                new ProductCategory(1, 1, 1), 
                new ProductCategory(2, 2, 2), 
                new ProductCategory(3, 3, 1)  
            };

            _mockProductRepo.Setup(r => r.GetAll()).Returns(products);
            _mockProductCategoryRepo.Setup(r => r.GetAll()).Returns(productCategories);

            _service = new ProductCategoryService(_mockProductRepo.Object, _mockProductCategoryRepo.Object);
        }

        [Test]
        public void GetProductsByCategoryId_ShouldReturnProductsForThatCategory()
        {
            // Act
            var result = _service.GetProductsByCategoryId(1);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Any(p => p.Name == "Melk"));
            Assert.That(result.Any(p => p.Name == "Kaas"));
        }

        [Test]
        public void GetProductsByCategoryId_ShouldReturnEmptyList_WhenCategoryNotFound()
        {
            var result = _service.GetProductsByCategoryId(99);

            Assert.That(result, Is.Empty);
        }
    }
}
