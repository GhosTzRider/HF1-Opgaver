using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF1_Øvelser_med_dependency_injection
{
    public interface IProductRepository
    {
        List<string> GetAllProducts();
        void AddProduct(string Name);
    }

    public class InMemoryProductRepository : IProductRepository
    {
        private List<string> _products = new List<string>();
        public List<string> GetAllProducts()
        {
            return _products;
        }
        public void AddProduct(string Name)
        {
            _products.Add(Name);
            Console.WriteLine($"Product '{Name}' added to the repository.");
        }
    }

    public class SqlProductRepository : IProductRepository
    {
        public List<string> GetAllProducts()
        {
            return new List<string> { "SQL Product 1", "SQL Product 2" };
        }
        public void AddProduct(string Name)
        {
            Console.WriteLine($"Product '{Name}' added to the SQL database.");
        }
    }

    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void AddProduct(string name)
        {
            _productRepository.AddProduct(name);
        }
        public List<string> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
