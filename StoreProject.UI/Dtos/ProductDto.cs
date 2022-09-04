using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject.UI.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "عنوان محصول را وارد کنید.")]
        [MaxLength(200, ErrorMessage = "عنوان نباید بیشتر از 200 کاراکتر باشد")]
        public string Title { get; set; }
        [Required(ErrorMessage = "آدرس عکس را وارد کنید.")]
        [MaxLength(300, ErrorMessage = "آدرس عکس نباید بیشتر از 300 کاراکتر باشد")]
        public string ImageName { get; set; }
        [Required(ErrorMessage = "قیمت را وارد کنید")]
        [MinLength(4, ErrorMessage = "تومان و 999999999 تومان باشد. 1000 قیمت باید بین ")]
        [MaxLength(9, ErrorMessage = "تومان و 999999999 تومان باشد. 1000 قیمت باید بین ")]
        public string Price { get; set; }
        [Required(ErrorMessage = "توضیحات کوتاه را وارد کنید.")]
        [MaxLength(300, ErrorMessage = "توضیحات کوتاه نباید بیشتر از 300 کاراکتر باشد")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "توضیحات را وارد کنید.")]
        [MaxLength(500, ErrorMessage = "توضیحات نباید بیشتر از 500 کاراکتر باشد")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int Views { get; set; }
    }
}
