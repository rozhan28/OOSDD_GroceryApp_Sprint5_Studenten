using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products;

        public ProductRepository()
        {
            products =
            [
                new Product(1, "Melk", 300, 1.49m, new DateOnly(2025, 9, 25)),
                new Product(2, "Kaas", 100, 3.79m, new DateOnly(2025, 9, 30)),
                new Product(3, "Brood", 400, 2.25m, new DateOnly(2025, 9, 12)),
                new Product(4, "Cornflakes", 0, 2.99m, new DateOnly(2025, 12, 31))
            ];
        }

        public List<Product> GetAll() => products;

        public Product? Get(int id) => products.FirstOrDefault(p => p.Id == id);

        public Product Add(Product item)
        {
            products.Add(item);
            return item;
        }

        public Product? Delete(Product item)
        {
            if (products.Remove(item))
                return item;
            return null;
        }

        public Product? Update(Product item)
        {
            Product? product = products.FirstOrDefault(p => p.Id == item.Id);
            if (product == null) return null;

            product.Name = item.Name;
            product.Stock = item.Stock;
            product.Price = item.Price;
            product.ShelfLife = item.ShelfLife;
            return product;
        }
    }
}
