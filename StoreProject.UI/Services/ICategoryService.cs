using StoreProject.UI.Dtos;

namespace StoreProject.UI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<ProductCategoryDto>> GetAllProductCategories(bool trackChanges);
        Task<IEnumerable<ProductCategoryDto>> GetAllProductCategoriesForAdmin(bool trackChanges);
        Task<ProductCategoryDto> GetProductCategoryById(Guid categoryId, bool trackChanges);
        Task CreateProductCategory(ProductCategoryDto productCategory);
        Task UpdateProductCategory(Guid categoryId, ProductCategoryDto productCategory);
        Task DeleteProductCategory(Guid categoryId);
    }
}
