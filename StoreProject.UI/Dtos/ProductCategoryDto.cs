using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.UI.Dtos
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [MaxLength(200, ErrorMessage = "طول نام نباید بیشتر از 200 کاراکتر باشد.")]
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
