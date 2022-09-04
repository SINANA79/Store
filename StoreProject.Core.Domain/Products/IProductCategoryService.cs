using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Core.Domain.Products
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetAllProductCategories(bool trackChanges);
        Task<IEnumerable<ProductCategory>> GetAllProductCategoriesForAdmin(bool trackChanges);
        Task<ProductCategory> GetProductCategoryById(Guid categoryId, bool trackChanges); 
        void CreateProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(ProductCategory productCategory);
    }
}
