
namespace Day2.Services
{
    public class CategoryService : ICategoryService
    {
        List<Category> _categories;
        int newCategoryID;

        public CategoryService()
        {
            _categories = new List<Category>()
            {
                new Category() {ID = 1, Name = "Electrics"},
                new Category() {ID = 2, Name = "Foods"},
                new Category() {ID = 3, Name = "Phones"},
                new Category() {ID = 4, Name = "Laptops"},
            };
        }

        public IEnumerable<Category>? GetAll()
            => _categories;

        public Category? GetByID(int id)
            => _categories?.SingleOrDefault(catg => catg.ID == id);

        public void Save(Category newCategory, bool isNew)
        {
            if (newCategory is not null)
            {
                if (isNew)
                {
                    newCategory.ID = newCategoryID;
                    _categories.Add(newCategory);
                }
                else
                {
                    Category? oldCategory = _categories.SingleOrDefault(p => p.ID == newCategory.ID);

                    if (oldCategory != null)
                        oldCategory.Name = newCategory.Name;
                }
            }
        }

        public void Delete(int id)
        {
            Category? existingCategory = _categories?.Find(p => p.ID == id);

            if (existingCategory is null)
                existingCategory = _categories?.SingleOrDefault(p => p.ID == id);

            if (existingCategory is not null)
                _categories?.Remove(existingCategory);
        }
    }
}
