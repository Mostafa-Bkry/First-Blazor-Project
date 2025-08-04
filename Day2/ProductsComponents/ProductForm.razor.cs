using Microsoft.AspNetCore.Components;

namespace Day2.ProductsComponents
{
    public partial class ProductForm
    {
        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public bool IsNew { get; set; } = true;

        public Product Product { get; set; } = new();

        public List<Category> Categories { get; set; } = new List<Category>();

        protected override void OnInitialized()
        {
            if (Id > 0)
                Product = ProductsServices?.GetByID(Id) ?? new Product();

            Categories = CategoryServices?.GetAll()?.ToList() ?? new List<Category>();

            base.OnInitialized();
        }

        void Save()
        {
            ProductsServices.Save(Product, IsNew);
            Navigation.NavigateTo($"ProductForm/{Product.ID}&false");
        }
    }
}
