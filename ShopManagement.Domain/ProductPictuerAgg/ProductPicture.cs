using Custom_FrameWork.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictuerAgg
{
    public class ProductPicture : EntityBase
    {


    
        public string PictureName { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemoved { get; private set; }

        public long ProdctId { get; private set; }
        public Product Product { get;private set; }


        public ProductPicture(long prodctId, string pictureName, string pictureAlt, string pictureTitle)
        {
            ProdctId = prodctId;
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemoved = false;
        }

        public void Eidt(long prodctId, string pictureName, string pictureAlt, string pictureTitle)
        {
            ProdctId = prodctId;
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
        }

        public void Removed()
        {
            IsRemoved = true;
        }
        public void Resotre()
        {

            IsRemoved = false;
        }
    }
}
