using Custom_FrameWork.Domain;
using System;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public ProductCategory(string name, string description, string pictureName,
            string pictureAlt, string pictureTitle, string keyWord,
            string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string PictureName { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWord { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }



        public void Edit(string name, string description, string pictureName,
            string pictureAlt, string pictureTitle, string keyWord,
            string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWord = keyWord;
            MetaDescription = metaDescription;
            Slug = slug;
        }
    }
}
