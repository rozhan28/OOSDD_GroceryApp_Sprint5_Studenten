using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public List<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            var allProducts = _productRepository.GetAll();
            var productCategories = _productCategoryRepository.GetAll();

            var filtered = from p in allProducts
                           join pc in productCategories on p.Id equals pc.ProductId
                           where pc.CategoryId == categoryId
                           select p;

            return filtered.ToList();
        }

        public ProductCategory Add(ProductCategory item)
        {
            return _productCategoryRepository.Add(item);
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            return _productCategoryRepository.Delete(item);
        }

        public ProductCategory? Get(int id)
        {
            return _productCategoryRepository.Get(id);
        }

        public ProductCategory? Update(ProductCategory item)
        {
            return _productCategoryRepository.Update(item);
        }
    }
}

