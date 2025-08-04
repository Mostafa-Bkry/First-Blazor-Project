using Microsoft.AspNetCore.Components;

namespace Day2.ProductsComponents
{
    public partial class ProductDetails
    {
        [Parameter]
        public int Id { get; set; }

        public Product Product { get; set; } = new();

        protected override void OnInitialized()
        {
            Product = ProductsServices?.GetByID(Id) ?? new Product();
            base.OnInitialized();
        }
    }
}
