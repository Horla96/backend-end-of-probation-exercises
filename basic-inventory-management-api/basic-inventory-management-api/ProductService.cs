using basic_inventory_management_api.Entities;
using System;
using System.Diagnostics.Metrics;

namespace basic_inventory_management_api
{
    public class ProductService : IProductService
    {
        private readonly Dictionary<Guid, Product> _products;
        public ProductService()
        {
            var products = new List<Product>
            {
                new Product(new Guid ("bfea4581-922f-4ae9-92d4-9a9f05220326"), "Toyota", "2025 model car", 2.2m, 10, Category.Cars),
                new Product(new Guid("35e7bdda-9b66-4ddd-b620-7ad016f14d59"),"Rice", "Imported rice", 50000, 50, Category.Foods),
                new Product(new Guid("bf871c9a-7f1e-42ab-9d57-d5ebbaf19c99"),"Ways to success", "Educative", 10000, 500, Category.Books),
            };


            _products = products.ToDictionary(p => p.Id);
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _products.Values;
        }


        public Product GetProductById(Guid id)
        {
            if (_products.TryGetValue(id, out var product))
            {
                return product;
            }

            return null; // or throw an exception, or handle as per your needs
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
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            if (!_products.ContainsKey(product.Id))
                throw new KeyNotFoundException("Product not found");

            _products[product.Id] = product;
        }

        public bool DeleteProduct(Guid id)
        {
            GetProductById(id);
            return _products.Remove(id);
        }

        public IEnumerable<Product> Search(string name = null, Category? category = null)
        {
            var query = _products.Values.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (category.HasValue)
                query = query.Where(p => p.Category == category.Value);

            return query;

        }
    }
}

