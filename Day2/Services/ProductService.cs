namespace Day2.Services
{
    public class ProductService : IProductService
    {
        private readonly ICategoryService _categoryService;
        List<Product> _products;
        int newProductID;

        public ProductService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _products = new List<Product>()
            {
                new Product() { ID = 1, Name = "iPhone 14", Description = "Apple smartphone with A15 chip", Image = "iphone14.jpg", Price = 999.99, CatgID = 1 },
                new Product() { ID = 2, Name = "Samsung Galaxy S22", Description = "Android flagship with great camera", Image = "galaxy_s22.jpg", Price = 849.99, CatgID = 1 },
                new Product() { ID = 3, Name = "Microwave Oven", Description = "800W digital microwave", Image = "microwave.jpg", Price = 199.50, CatgID = 2 },
                new Product() { ID = 4, Name = "LED TV 55\"", Description = "4K Ultra HD Smart TV", Image = "led_tv.jpg", Price = 499.99, CatgID = 2 },
                new Product() { ID = 5, Name = "Dell XPS 13", Description = "Ultrabook with Intel i7", Image = "xps13.jpg", Price = 1199.00, CatgID = 3 },
                new Product() { ID = 6, Name = "MacBook Air M2", Description = "Apple's M2 chip laptop", Image = "macbook_air.jpg", Price = 1249.00, CatgID = 3 },
                new Product() { ID = 7, Name = "Bananas", Description = "Fresh organic bananas", Image = "bananas.jpg", Price = 2.99, CatgID = 4 },
                new Product() { ID = 8, Name = "Cheddar Cheese", Description = "Aged sharp cheddar", Image = "cheese.jpg", Price = 4.50, CatgID = 4 },
                new Product() { ID = 9, Name = "Pixel 7", Description = "Google’s flagship Android phone", Image = "pixel7.jpg", Price = 799.00, CatgID = 1 },
                new Product() { ID = 10, Name = "Air Fryer", Description = "Oil-less cooking appliance", Image = "air_fryer.jpg", Price = 149.99, CatgID = 2 },
                new Product() { ID = 11, Name = "HP Pavilion", Description = "Budget laptop with AMD Ryzen", Image = "hp_pavilion.jpg", Price = 649.00, CatgID = 3 },
                new Product() { ID = 12, Name = "Dark Chocolate", Description = "85% cocoa premium bar", Image = "chocolate.jpg", Price = 3.99, CatgID = 4 },
            };
        }

        public IEnumerable<Product>? GetAll()
            => _products;

        public Product? GetByID(int id)
            => _products?.SingleOrDefault(p => p.ID == id);

        public int GetNextNewProductID()
        {
            newProductID = (_products?.LastOrDefault()?.ID + 1) ?? 0;
            return newProductID;
        }

        public void Save(Product? newProduct, bool isNew)
        {
            if (newProduct is not null)
            {
                if (isNew)
                {
                    newProduct.ID = newProductID;
                    _products.Add(newProduct);
                }
                else
                {
                    Product? oldProduct = _products.SingleOrDefault(p => p.ID == newProduct.ID);

                    if (oldProduct != null)
                    {
                        oldProduct.Name = newProduct.Name;
                        oldProduct.Description = newProduct.Description;
                        oldProduct.Price = newProduct.Price;
                        oldProduct.Image = newProduct.Image;
                        if(oldProduct.CatgID != newProduct.CatgID && _categoryService?.GetByID(newProduct.CatgID) != null)
                            oldProduct.CatgID = newProduct.CatgID;
                    }
                }
            }
        }

        public void Delete(int id)
        {
            Product? existingProduct = _products?.Find(p => p.ID == id);

            if (existingProduct is null)
                existingProduct = _products?.SingleOrDefault(p => p.ID == id);

            if(existingProduct is not null)
                _products?.Remove(existingProduct);
        }
    }
}
