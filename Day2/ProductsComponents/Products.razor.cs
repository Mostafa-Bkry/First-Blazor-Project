namespace Day2.ProductsComponents
{
    public partial class Products
    {
        List<Product> products = new();

        public int NewProductID { get; set; }

        protected override void OnInitialized()
        {
            products = ProductsServices?.GetAll()?.ToList() ?? new List<Product>();
            base.OnInitialized();
        }

        void GetNewID()
        {
            NewProductID = ProductsServices.GetNextNewProductID();
        }
    }
}
