namespace Day2.ProductsComponents
{
    public partial class Products
    {
        List<Product> products = new();

        public int NewProductID { get; set; }

        public int ProducIDToBeDeleted { get; set; }
        public string ProductNameToBeDeleted { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            products = ProductsServices?.GetAll()?.ToList() ?? new List<Product>();
            base.OnInitialized();
        }

        void GetNewID()
        {
            NewProductID = ProductsServices.GetNextNewProductID();
        }

        void GetProductNameThatWillBeDeleted(int id)
        {
            ProducIDToBeDeleted = id;
            ProductNameToBeDeleted = ProductsServices?.GetByID(id)?.Name ?? string.Empty;
        }

        void DeleteProduct()
        {
            ProductsServices.Delete(ProducIDToBeDeleted);
            products = ProductsServices?.GetAll()?.ToList() ?? new List<Product>();
        }
    }
}
