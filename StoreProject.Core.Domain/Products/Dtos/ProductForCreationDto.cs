using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Core.Domain.Products.Dtos
{
    public class ProductForCreationDto
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ProductCategoryDto? Product { get; set; }
    }
}
