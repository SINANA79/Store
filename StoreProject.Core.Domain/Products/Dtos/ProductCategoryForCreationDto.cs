using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Core.Domain.Products.Dtos
{
    public class ProductCategoryForCreationDto
    {
        public string Title { get; set; }
        //public string UrlName { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<ProductForCreationDto>? Products { get; set; }
    }
}
