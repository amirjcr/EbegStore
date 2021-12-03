using Custom_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SliderAgg
{
    public class Slide : EntityBase
    {
        public Slide(string pictureName, string pictureAlt,
            string pictureTitel, string heading, string titel,
            string text, string btnText,string link)
        {
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitel = pictureTitel;
            Heading = heading;
            Titel = titel;
            Text = text;
            BtnText = btnText;
            IsRemoved = false;
            Link = link;
        }

        public string PictureName { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitel { get; private set; }
        public string Heading { get; private set; }
        public string Titel { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public bool IsRemoved { get; private set; }
        public string Link { get; private set; }


        public void Edit(string pictureName, string pictureAlt,
                      string pictureTitel, string heading, string titel,
                       string text, string btnText,string link)
        {
            PictureName = pictureName;
            PictureAlt = pictureAlt;
            PictureTitel = pictureTitel;
            Heading = heading;
            Titel = titel;
            Text = text;
            BtnText = btnText;
            Link = link;
        }


        public void Remove() => IsRemoved = true;
        public void Restore() => IsRemoved = false;
    }
}
