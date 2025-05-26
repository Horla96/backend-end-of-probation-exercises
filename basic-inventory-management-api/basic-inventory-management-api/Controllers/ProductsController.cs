using basic_inventory_management_api.Entities;
using Microsoft.AspNetCore.Mvc;


namespace basic_inventory_management_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]

        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public ActionResult<Product> GetById (Guid id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]

        public ActionResult AddProduct(Product product)
        {
                _productService.AddProduct(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
 
        }

        [HttpPut]

        public ActionResult updateProduct (Product product)
        {
            _productService.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete]

        public ActionResult DeleteProduct (Guid Id)
        {
            _productService.DeleteProduct(Id);
            return Ok();
        }

        [HttpGet("search")]

        public ActionResult<IEnumerable<Product>> Search([FromQuery] string name, [FromQuery] Category? category)
        {
            var results = _productService.Search(name, category);
            return Ok(results);
        }
    }
    
}
