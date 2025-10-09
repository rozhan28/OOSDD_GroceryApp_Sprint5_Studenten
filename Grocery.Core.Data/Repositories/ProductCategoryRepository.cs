using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = new List<ProductCategory>
            {
                new ProductCategory(1, 1, 1),
                new ProductCategory(2, 2, 1),
                new ProductCategory(3, 3, 2), 
                new ProductCategory(4, 4, 4), 
                new ProductCategory(5, 4, 3)  
            };
        }

        public List<ProductCategory> GetAll() => productCategories;

        public ProductCategory? Get(int id) => productCategories.FirstOrDefault(pc => pc.Id == id);

        public List<ProductCategory> GetAllByCategoryId(int categoryId)
            => productCategories.Where(pc => pc.CategoryId == categoryId).ToList();

        public List<ProductCategory> GetAllByProductId(int productId)
            => productCategories.Where(pc => pc.ProductId == productId).ToList();

        public ProductCategory Add(ProductCategory item)
        {
            productCategories.Add(item);
            return item;
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            if (productCategories.Remove(item)) return item;
            return null;
        }

        public ProductCategory? Update(ProductCategory item)
        {
            var pc = productCategories.FirstOrDefault(x => x.Id == item.Id);
            if (pc == null) return null;
            pc.ProductId = item.ProductId;
            pc.CategoryId = item.CategoryId;
            return pc;
        }
    }
}

