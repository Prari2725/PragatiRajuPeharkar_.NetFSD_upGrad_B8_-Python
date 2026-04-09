using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
    }
}
