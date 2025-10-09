using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Models;
using Grocery.Core.Interfaces.Services;
using Grocery.App.Views;
using System.Collections.ObjectModel;


namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : ObservableObject
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            LoadCategories();
        }

        [ObservableProperty]
        private List<Category> categories = new();

        private void LoadCategories()
        {
            Categories = _categoryService.GetAll();
        }

        [RelayCommand]
        private async Task SelectCategory(Category category)
        {
            if (category == null) return;
            await Shell.Current.GoToAsync($"{nameof(ProductCategoriesView)}?categoryId={category.Id}");
        }

        [RelayCommand]
        private void Refresh()
        {
            LoadCategories();
        }
    }
}
