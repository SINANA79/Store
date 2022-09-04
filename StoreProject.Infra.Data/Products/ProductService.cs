using Microsoft.EntityFrameworkCore;
using StoreProject.Core.Domain.Products;
using StoreProject.Infra.Data.Base;
using StoreProject.Infra.Data.Common;

namespace StoreProject.Infra.Data.Products
{
    public class ProductService : RepositoryBase<Product>, IProductService
    {

        public ProductService(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProducts(bool trackChanges) =>
    await FindByCondition(e => e.IsActive, trackChanges).ToListAsync();

        public async Task<IEnumerable<Product>> GetAllProductsById(Guid categoryId, bool trackChanges)
        {
            return await FindByCondition(e => e.CategoryId.Equals(categoryId) && e.IsActive, trackChanges).ToListAsync();
        }

        public async Task<Product> GetProductById(Guid categoryId, Guid id, bool trackChanges) =>
            await FindByCondition(e =>
                e.CategoryId.Equals(categoryId) && e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Product>> SearchProducts(string searchText, bool trackChanges) =>
             await FindByCondition(e => e.Title.Contains(searchText) ||
                e.ShortDescription.Contains(searchText) ||
                e.Description.Contains(searchText), trackChanges).ToListAsync();



            public void CreateProduct(Guid categoryId, Product product)
        {
            product.CategoryId = categoryId;
            Create(product);
        }

        public void UpdateProduct(Product product) => Update(product);

        public void DeleteProduct(Product product) => Delete(product);

        public async Task<IEnumerable<Product>> GetAllProductsByIdForAdmin(Guid categoryId, bool trackChanges)
        {
            return await FindByCondition(e => e.CategoryId.Equals(categoryId), trackChanges).ToListAsync();
        }
    }
}
