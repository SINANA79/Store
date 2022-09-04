using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.Core.Domain.Products.Dtos
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        //public string UrlName { get; set; }
        public bool IsActive { get; set; }
    }
}
