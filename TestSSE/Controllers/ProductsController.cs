using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSSE.Models;
using Microsoft.Extensions.Logging;
//using TestSSE.Services;

namespace TestSSE.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

      //  private readonly IProductInfoRepository _productInfoRepository;

       // public ProductsController(IProductInfoRepository productInfoRepository)
       // {
       //     _productInfoRepository = productInfoRepository ?? throw new ArgumentNullException(nameof(productInfoRepository));
       // }

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
           return Ok(ProductsDataStore.Current.Products);
        }
        [HttpGet("product/{id}", Name ="GetProduct")]
        public IActionResult GetProduct(int id)
        {
            //find product
            var productToReturn = ProductsDataStore.Current.Products.FirstOrDefault(c => c.Id == id);

            if (productToReturn == null)
            {
                return NotFound();
            }

            return Ok(productToReturn);

           //return new JsonResult(ProductsDataStore.Current.Products.FirstOrDefault(c => c.Id == id));
        }
        [HttpPost("product")]
        public IActionResult CreateProduct ([FromBody] ProductCreation product)
        {
            
            var maxProductId = ProductsDataStore.Current.Products.Max(p => p.Id);
            var newProduct = new ProductDto()
            {
                Id = ++maxProductId,
                Name = product.Name,    
                Price = product.Price
            };

            ProductsDataStore.Current.Products.Add(newProduct);

            var productToReturn = ProductsDataStore.Current.Products.FirstOrDefault(c => c.Id == newProduct.Id);
            return Ok(productToReturn);
        }
        [HttpPut("product/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductUpdate product)
        {
            var productToUpdate = ProductsDataStore.Current.Products.FirstOrDefault(c => c.Id == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            if (product.Name != null)
            {
                productToUpdate.Name = product.Name;
            }
            if (product.Price != null)
            {
                productToUpdate.Price = product.Price;
            }
            var productToReturn = ProductsDataStore.Current.Products.FirstOrDefault(c => c.Id == id);
            if (productToReturn == null)
            {
                return NotFound();
            }

            return Ok(productToReturn);
        }

        [HttpDelete("product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var productToDelete = ProductsDataStore.Current.Products.FirstOrDefault(c => c.Id == id);
            if (productToDelete == null)
            {
                return NotFound();
            }
            ProductsDataStore.Current.Products.Remove(productToDelete);

            return Ok();

        }
    }
}
