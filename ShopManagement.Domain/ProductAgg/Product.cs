using Custom_FrameWork.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictuerAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {
        public Product(string name,
            string code, string shortDescription,
            string description, string pictureName, string pictureAlt,
            string pictureTitel, string slug, string keyWords,
            string metaDescription,
            long categoryId)
        {
            Name = name;
            Code = code;

            ShortDescription = shortDescription;
            Description = description;
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitel = pictureTitel;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string PictureName { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitel { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }

        public long CategoryId { get; private set; }
        public ProductCategory Category { get; private set; }
        public ICollection<ProductPicture> ProductPictures { get; private set; }




        public void Edit(string name,
    string code, string shortDescription,
    string description, string pictureName, string pictureAlt,
    string pictureTitel, string slug, string keyWords,
    string metaDescription)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitel = pictureTitel;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
        }
    }
}

