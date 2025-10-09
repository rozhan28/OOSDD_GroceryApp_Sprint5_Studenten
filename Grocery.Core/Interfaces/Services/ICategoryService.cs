using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category? Get(int id);
        Category Add(Category item);
        Category? Update(Category item);
        Category? Delete(Category item);
    }
}

