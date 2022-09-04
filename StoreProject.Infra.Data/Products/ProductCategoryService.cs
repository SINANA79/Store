using Microsoft.EntityFrameworkCore;
using StoreProject.Core.Domain.Products;
using StoreProject.Infra.Data.Base;
using StoreProject.Infra.Data.Common;

namespace StoreProject.Infra.Data.Products
{
    public class ProductCategoryService : RepositoryBase<ProductCategory>, IProductCategoryService
    {
        public ProductCategoryService(StoreDbContext storeDbContext) : base(storeDbContext)
        {
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategories(bool trackChanges) =>
            await FindByCondition(e => e.IsActive, trackChanges).ToListAsync();

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesForAdmin(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<ProductCategory> GetProductCategoryById(Guid categoryId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(categoryId), trackChanges).SingleOrDefaultAsync();
        

        public void CreateProductCategory(ProductCategory productCategory) => Create(productCategory);

        public void UpdateProductCategory(ProductCategory productCategory) => Update(productCategory);

        public void DeleteProductCategory(ProductCategory productCategory) => Delete(productCategory);


    }
}
