namespace basic_inventory_management_api.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public Category Category { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public Product(Guid id, string name, string description, decimal price, int quantityInStock, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            QuantityInStock = quantityInStock;
            Category = category;
        }
            
           

    }
}
