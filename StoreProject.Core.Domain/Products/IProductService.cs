using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Core.Domain.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts(bool trackChanges);
        Task<IEnumerable<Product>> GetAllProductsByIdForAdmin(Guid categoryId, bool trackChanges);
        Task<IEnumerable<Product>> GetAllProductsById(Guid categoryId, bool trackChanges);
        Task<Product> GetProductById(Guid categoryId, Guid id, bool trackChanges);
        Task<IEnumerable<Product>> SearchProducts(string searchText, bool trackChanges);
        void CreateProduct(Guid categoryId, Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
