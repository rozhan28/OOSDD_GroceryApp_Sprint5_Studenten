﻿using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll() => _categoryRepository.GetAll();

        public Category? Get(int id) => _categoryRepository.Get(id);

        public Category Add(Category item) => _categoryRepository.Add(item);

        public Category? Update(Category item) => _categoryRepository.Update(item);

        public Category? Delete(Category item) => _categoryRepository.Delete(item);
    }
}
