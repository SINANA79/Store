using StoreProject.UI.Dtos;

namespace StoreProject.UI.Services
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(ProductCategoryDto categoryDto, CartItem item);
        Task<List<CartItem>> GetCartItems();
        Task DeleteItem(CartItem item);
        Task EmptyCart();
    }
}
