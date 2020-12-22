using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud.Models;

namespace Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _productRepository.GetProducts().ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productRepository.GetSingleProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        [HttpPut("{id}")]
        public ActionResult<Product> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

          try
            {
                return _productRepository.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        [HttpPost("search")]
        public ActionResult<IEnumerable<Product>> SearchProduct(string searchKey)
        {
            
            if (!string.IsNullOrEmpty(searchKey))
            {
                return _productRepository.SearchProduct(searchKey).ToList();
            }

            return _productRepository.GetProducts().ToList();
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _productRepository.DeleteProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
    }
}
