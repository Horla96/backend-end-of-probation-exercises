using basic_inventory_management_api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

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
            return products;
        }

        [HttpGet("{id}")]

        public ActionResult<Product> GetById (Guid id)
        {
            var product = _productService.GetProductById(id);
            return OK(product);
        }

        [HttpPost]

        public ActionResult AddProduct(Product product)
        {
                _productService.AddProduct(product);
                return CreatedAction(nameof(GetById), new { id = product.Id }, product);
 
        }

        [HttpPut]

        public ActionResult updateProduct (Product product)
        {
            var updateProduct = _productService.UpdateProduct(product);
            return updateProduct;
        }

        [HttpDelete]

        public ActionResult DeleteProduct (Product product)
        {
            var removed = _productService.DeleteProduct(product);
            return DeleteProduct(removed);
        }

        [HttpGet("search")]

        public ActionResult<IEnumerable<Product>> Search([FromQuery] string name, [FromQuery] Category? category)
        {
            var results = _productService.Search(name, category);
            return Ok(results);
        }
    }
    
}
