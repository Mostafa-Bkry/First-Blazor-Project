namespace Day2.Services
{
    public interface ICategoryService
    {
        Category? GetByID(int id);
        IEnumerable<Category>? GetAll();

        void Save(Category newCategory, bool isNew);
        void Delete(int id);
    }
}
