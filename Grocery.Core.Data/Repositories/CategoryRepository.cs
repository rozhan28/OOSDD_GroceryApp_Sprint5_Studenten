using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;

        public CategoryRepository()
        {
            categories = new List<Category>
            {
                new Category(1, "Zuivel"),
                new Category(2, "Bakery"),
                new Category(3, "Ontbijt"),
                new Category(4, "Cornflakes & Cereals")
            };
        }

        public List<Category> GetAll() => categories;

        public Category? Get(int id) => categories.FirstOrDefault(c => c.Id == id);

        public Category Add(Category item)
        {
            categories.Add(item);
            return item;
        }

        public Category? Delete(Category item)
        {
            if (categories.Remove(item))
                return item;
            return null;
        }

        public Category? Update(Category item)
        {
            var c = categories.FirstOrDefault(x => x.Id == item.Id);
            if (c == null) return null;
            c.Name = item.Name;
            return c;
        }
    }
}

