namespace StoreProject.UI.Dtos
{
    public class ProductDtoCId
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Guid CategoryId { get; set; }
    }
}
