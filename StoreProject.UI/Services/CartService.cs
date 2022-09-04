using Blazored.LocalStorage;
using Blazored.Toast.Services;
using StoreProject.UI.Dtos;

namespace StoreProject.UI.Services
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;
        private readonly IProductService _productService;

        public event Action OnChange;

        public CartService(ILocalStorageService localStorage,
            IToastService toastService,
            IProductService productService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;
        }

        public async Task AddToCart(ProductCategoryDto categoryDto, CartItem item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if(cart == null)
            {
                cart = new List<CartItem>();
            }

            var sameItem = cart.Find(x => x.Id == item.Id);
            if (sameItem == null)
                cart.Add(item);
            else
                sameItem.Quantity += item.Quantity;
            await _localStorage.SetItemAsync("cart", cart);
            var product = await _productService.GetProductById(categoryDto.Id, item.Id, false);
            _toastService.ShowSuccess(item.Title, "به سبد خرید اضافه شد");
            OnChange.Invoke();

        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return new List<CartItem>();
            }
            return cart;
        }

        public async Task DeleteItem(CartItem item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(x => x.Id == item.Id);
            cart.Remove(cartItem);

            await _localStorage.SetItemAsync("cart", cart);
            OnChange.Invoke();
        }

        public async Task EmptyCart()
        {
            await _localStorage.RemoveItemAsync("cart");
            OnChange.Invoke();
        }
    }
}
