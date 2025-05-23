using basic_inventory_management_api.Entities;

namespace basic_inventory_management_api
{
    public class ProductService : IProductService
    {
        private readonly Dictionary<Guid, Product> _products;
        public ProductService()
        {
            var products = new List<Product>
            {
                new Product("Toyota", "2025 model car", 2.2m, 10, Category.Cars),
                new Product("Rice", "Imported rice", 50, 000, 50, Category.Foods),
                new Product("Ways to success", "Educative", 10,000, 500, Category.Books),
            };


            _products = products.ToDictionary(p => p.Id);
        }
        
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _product.values;
    }
    
    public Product GetProductById(Guid id)
    {
        _products.GetValue(id, out var product);
        return Product;
    }

    public void AddProduct(Product product)
    {
        //if (product is null)
        //    throw new ArgumentNullException(nameof(product));
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name cannot be empty");

        if (product.Price <= 0)
            throw new ArgumentException("Price most be grater than zero");

        if (product.QuantityInStock < 0)
            throw new ArgumentException("Quantity cannot be negative");

        _products[product.Id] = product;

    }

    public void UpdateProduct(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));
        if (!product.Containskey(product.Id))
            throw KeyNotFoundException("Product not found");
        _products[product.Id] = product;
    }

    public bool DeleteProduct(Guid id)
    {
        return _products.Remove(id);
    }

    public IEnumerable<Product> Search(string name = null, Category? category = null)
    {
        var query = _products.Values.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(p => p.Name.Contains(name, stringComparison.OriginalIgnoreCase));
        if (category.HasValue)
            query = query.Where(p => p.Category == category.Value);

        return query;

    }
}

