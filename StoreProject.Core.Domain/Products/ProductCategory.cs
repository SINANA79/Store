using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Core.Domain.Products
{
    public class ProductCategory
    {
        [Column("ProductCategoryId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Product category title is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the category is 200 characters.")]
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }

}
