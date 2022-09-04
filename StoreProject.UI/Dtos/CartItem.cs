namespace StoreProject.UI.Dtos
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
    }
}
