using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Models;
using Grocery.Core.Interfaces.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(CategoryId), "categoryId")]
    public partial class ProductCategoriesViewModel : ObservableObject
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        [ObservableProperty]
        private ObservableCollection<Product> products = [];

        [ObservableProperty]
        private int categoryId;

        partial void OnCategoryIdChanged(int value)
        {
            LoadProductsByCategoryId(value);
        }

        public ProductCategoriesViewModel(
            IProductService productService,
            IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        public void LoadProductsByCategoryId(int categoryId)
        {
            var allProducts = _productService.GetAll();
            var productCategories = _productCategoryService.GetAll();

            var filtered = from p in allProducts
                           join pc in productCategories on p.Id equals pc.ProductId
                           where pc.CategoryId == categoryId
                           select p;

            Products = new ObservableCollection<Product>(filtered);
        }
    }
}

