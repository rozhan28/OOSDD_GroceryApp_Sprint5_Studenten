using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category? Get(int id);
        Category Add(Category item);
        Category? Update(Category item);
        Category? Delete(Category item);
    }
}

