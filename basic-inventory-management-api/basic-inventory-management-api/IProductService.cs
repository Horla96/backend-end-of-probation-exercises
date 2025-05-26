using basic_inventory_management_api.Entities;

namespace basic_inventory_management_api
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(Guid id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        bool DeleteProduct(Guid id);

        public IEnumerable<Product> Search(string name = null, Category? category = null);
    }
}
