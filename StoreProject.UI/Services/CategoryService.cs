using System.Net.Http.Json;
using StoreProject.UI.Dtos;

namespace StoreProject.UI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }
        public async Task CreateProductCategory(ProductCategoryDto productCategory)
        {
            await _http.PostAsJsonAsync("/api/productCategory", productCategory);
        }

        public Task DeleteProductCategory(Guid categoryId)
        {
            return _http.DeleteAsync($"/api/productCategory/{categoryId}");
        }

        public Task<IEnumerable<ProductCategoryDto>> GetAllProductCategories(bool trackChanges)
        {
            return _http.GetFromJsonAsync<IEnumerable<ProductCategoryDto>>("/api/productCategory");
        }

        public Task<IEnumerable<ProductCategoryDto>> GetAllProductCategoriesForAdmin(bool trackChanges)
        {
            return _http.GetFromJsonAsync<IEnumerable<ProductCategoryDto>>("/api/productCategoryAdmin");
        }

        public Task<ProductCategoryDto> GetProductCategoryById(Guid categoryId, bool trackChanges)
        {
            return _http.GetFromJsonAsync<ProductCategoryDto>($"/api/productCategory/{categoryId}");
        }

        public Task UpdateProductCategory(Guid categoryId, ProductCategoryDto productCategory)
        {
            return _http.PutAsJsonAsync($"/api/productCategory/{categoryId}", productCategory);
        }
    }
}
