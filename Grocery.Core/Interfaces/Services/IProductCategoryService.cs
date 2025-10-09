using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetAll();
        ProductCategory? Get(int id);
        List<ProductCategory> GetAllByCategoryId(int categoryId);
        List<ProductCategory> GetAllByProductId(int productId);
        ProductCategory Add(ProductCategory item);
        ProductCategory? Update(ProductCategory item);
        ProductCategory? Delete(ProductCategory item);
    }
}
