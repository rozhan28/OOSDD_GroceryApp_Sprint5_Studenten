using Grocery.Core.Models;
using System.Collections.Generic;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetAll();
        List<Product> GetProductsByCategoryId(int categoryId);
        ProductCategory Add(ProductCategory item);
        ProductCategory? Delete(ProductCategory item);
        ProductCategory? Get(int id);
        ProductCategory? Update(ProductCategory item);
    }
}

