using System.Collections.Generic;

namespace Crud.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetSingleProduct(int Id);
        IEnumerable<Product> SearchProduct(string searchKey);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(int Id);
    }
}
