using Custom_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Products
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Code { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get; set; }
        public bool IsInStock { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string PictureName { get; set; }


        public string PictureAlt { get; set; }
        public string PictureTitel { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescription { get; set; }


        [Range(1, 100_000, ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }

        public List<ProductCategoryviewModel> Categories { get; set; }

        public List<ProductViewModel> Products { get; set; }

    }

}
