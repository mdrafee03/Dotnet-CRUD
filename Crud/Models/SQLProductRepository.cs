using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Crud.Models
{
    public class SQLProductRepository : IProductRepository
    {
        public AppDbContext _context { get; }
        public SQLProductRepository(AppDbContext context)
        {
            _context = context;
        }


        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int Id)
        {
            var product = _context.Products.Find(Id);
            if (product != null)
            {
            _context.Products.Remove(product);
            _context.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        public Product GetSingleProduct(int Id)
        {
            return _context.Products.Find(Id);  
        }

        public IEnumerable<Product> SearchProduct(string searchKey)
        {
            return _context.Products.Where(product => product.Name.Contains(searchKey)).ToList();
        }

        public Product UpdateProduct(Product productChanges)
        {
            var product = _context.Products.Attach(productChanges);
            product.State = EntityState.Modified;
            _context.SaveChanges();
            return productChanges;
        }
    }
}
