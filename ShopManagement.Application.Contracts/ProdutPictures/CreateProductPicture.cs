using Custom_FrameWork.Application;
using ShopManagement.Application.Contracts.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProdutPictures
{
    public class CreateProductPicture
    {
        [Range(1,100_000,ErrorMessage =ValidationMessages.OutofRange)]
        public long ProdctId { get; set; }

        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string PictureName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }


}
