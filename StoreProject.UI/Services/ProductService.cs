using StoreProject.UI.Dtos;
using System.Net.Http.Json;

namespace StoreProject.UI.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }
        public Task CreateProduct(Guid categoryId, ProductDto product)
        {
            return _http.PostAsJsonAsync($"/api/productCategory/{categoryId}/product", product);
        }

        public Task DeleteProduct(Guid categoryId, Guid productId)
        {
            return _http.DeleteAsync($"api/productCategory/{categoryId}/product/{productId}");
        }

        public Task<IEnumerable<ProductDtoCId>> GetAllProducts(bool trackChanges)
        {
            return _http.GetFromJsonAsync<IEnumerable<ProductDtoCId>>("/api/product");
        }

        public Task<IEnumerable<ProductDto>> GetAllProductsById(Guid categoryId, bool trackChanges)
        {
            return _http.GetFromJsonAsync<IEnumerable<ProductDto>>($"/api/productCategory/{categoryId}/product");
        }

        public Task<IEnumerable<ProductDto>> GetAllProductsByIdForAdmin(Guid categoryId, bool trackChanges)
        {
            return _http.GetFromJsonAsync<IEnumerable<ProductDto>>($"/api/productCategory/{categoryId}/productAdmin");
        }

        public Task<ProductDto> GetProductById(Guid categoryId, Guid id, bool trackChanges)
        {
            return _http.GetFromJsonAsync<ProductDto>($"/api/productCategory/{categoryId}/product/{id}");
        }

        public Task UpdateProduct(Guid categoryId, Guid productId, ProductDto product)
        {
            return _http.PutAsJsonAsync($"/api/productCategory/{categoryId}/product/{productId}", product);
        }

        public async Task<IEnumerable<ProductDtoCId>> SearchProducts(string searchText)
        {
            return await _http.GetFromJsonAsync<IEnumerable<ProductDtoCId>>($"/api/search/{searchText}");
        }
    }
}
