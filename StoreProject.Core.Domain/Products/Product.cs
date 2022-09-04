using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreProject.Core.Domain.Products
{
    public class Product
    {
        [Column("ProductId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Product title is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the title is 200 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Product image is a required field.")]
        [MaxLength(300, ErrorMessage = "Maximum length for the image is 300 characters.")]
        public string ImageName { get; set; }
        [Required(ErrorMessage = "Product price is a required field.")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Description is a required field.")]
        public string Description { get; set; }
        public string Price { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey(nameof(ProductCategory))]
        public Guid CategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }


}
