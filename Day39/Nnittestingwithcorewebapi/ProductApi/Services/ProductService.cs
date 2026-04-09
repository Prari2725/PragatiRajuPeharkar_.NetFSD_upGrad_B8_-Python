using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000 },
            new Product { Id = 2, Name = "Mobile", Price = 20000 }
        };

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }
    }
}

