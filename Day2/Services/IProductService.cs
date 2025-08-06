namespace Day2.Services
{
    public interface IProductService
    {
        int GetNextNewProductID();

        Product? GetByID(int id);
        IEnumerable<Product>? GetAll();

        void Save(Product? newProduct, bool isNew);
        void Delete(int id);
    }
}
