using NUnit.Framework;
using Grocery.Core.Models;
using System;

namespace Grocery.Tests.Models
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_ShouldSet_AllPropertiesCorrectly()
        {
            // Arrange
            int id = 1;
            string name = "Appel";
            int stock = 50;
            decimal price = 0.99m;
            DateOnly shelfLife = new DateOnly(2025, 12, 31);

            // Act
            var product = new Product(id, name, stock, price, shelfLife);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(product.Id, Is.EqualTo(id));
                Assert.That(product.Name, Is.EqualTo(name));
                Assert.That(product.Stock, Is.EqualTo(stock));
                Assert.That(product.Price, Is.EqualTo(price));
                Assert.That(product.ShelfLife, Is.EqualTo(shelfLife));
            });
        }

        [Test]
        public void ToString_ShouldReturnReadableString_WithPrice()
        {
            // Arrange
            var product = new Product(1, "Melk", 10, 1.49m, new DateOnly(2025, 10, 31));

            // Act
            string result = product.ToString();

            // Assert
            Assert.That(result, Does.Contain("Melk"));
            Assert.That(result, Does.Contain("10"));
            Assert.That(result, Does.Contain("€1.49"));
        }

        [Test]
        public void Price_ShouldTrigger_PropertyChangedEvent_WhenChanged()
        {
            // Arrange
            var product = new Product(1, "Banaan", 20, 0.79m, new DateOnly(2025, 12, 1));
            bool eventTriggered = false;

            product.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName != null && args.PropertyName == nameof(Product.Price))
                    eventTriggered = true;
            };

            // Act
            product.Price = 0.89m;

            // Assert
            Assert.That(eventTriggered, Is.True, "Price property did not trigger PropertyChanged event.");
            Assert.That(product.Price, Is.EqualTo(0.89m));
        }
    }
}
