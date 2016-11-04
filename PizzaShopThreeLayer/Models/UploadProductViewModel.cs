using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PizzaShopThreeLayer.Models
{
    public class UploadProductViewModel
    {
        [ScaffoldColumn(false)]
        public HttpPostedFileBase Image { get; set; }


        [Required(ErrorMessage = "Введите наименование товара")]
        [Display(Name = "Наименование")]
        [StringLength(maximumLength:30,MinimumLength = 2,ErrorMessage = "Введите название от 2 до 30 символов")]
        public string Name { get; set; }

         [ScaffoldColumn(false)]
        public string Absolutepath { get; set; }

        [Required(ErrorMessage = "Введите описание товара")]
        [Display(Name = "Описание")]
        [StringLength(maximumLength:120,MinimumLength = 5,ErrorMessage = "Введите описание от 5 до 120 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите цену товара")]
        [Display(Name = "Цена")]
        [Range(minimum:0.1,maximum:10000000,ErrorMessage = "Введите цену от 0 до 100000")]
        public decimal Price { get; set; }
    }
}