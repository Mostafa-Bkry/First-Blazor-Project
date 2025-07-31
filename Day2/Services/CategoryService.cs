
namespace Day2.Services
{
    public class CategoryService : ICategoryService
    {
        List<Category> _categories;

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
            throw new NotImplementedException();
        }
    }
}
