using StoreProject.UI.Dtos;

namespace StoreProject.UI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDtoCId>> GetAllProducts(bool trackChanges);
        Task<IEnumerable<ProductDto>> GetAllProductsById(Guid categoryId, bool trackChanges);
        Task<IEnumerable<ProductDto>> GetAllProductsByIdForAdmin(Guid categoryId, bool trackChanges);
        Task<ProductDto> GetProductById(Guid categoryId, Guid id, bool trackChanges);
        Task CreateProduct(Guid categoryId, ProductDto product);
        Task UpdateProduct(Guid categoryId, Guid productId, ProductDto product);
        Task DeleteProduct(Guid categoryId, Guid productId);
        Task<IEnumerable<ProductDtoCId>> SearchProducts(string searchText);
    }
}
