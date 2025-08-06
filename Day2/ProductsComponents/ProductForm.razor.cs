using Microsoft.AspNetCore.Components;

namespace Day2.ProductsComponents
{
    public partial class ProductForm
    {
        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public bool IsNew { get; set; } = true;

        public Product? Product { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

        protected override void OnInitialized()
        {
            //if (Id > 0)
            //    Product = ProductsServices?.GetByID(Id) ?? (IsNew ? new Product() : null);

            if (Id > 0 && IsNew)
                Product = new Product();

            if(Id > 0 && !IsNew)
                Product = ProductsServices?.GetByID(Id);

            Categories = CategoryServices?.GetAll()?.ToList() ?? new List<Category>();

            base.OnInitialized();
        }

        void Save()
        {
            int id = ProductsServices.GetNextNewProductID();
            if (Product is not null)
            {
                Product.ID = id;
                ProductsServices.Save(Product, IsNew);
                Navigation.NavigateTo($"ProductForm/{Product.ID}&false");
                return;
            }

            Navigation.NavigateTo($"ProductForm/{id}&false");
        }
    }
}
