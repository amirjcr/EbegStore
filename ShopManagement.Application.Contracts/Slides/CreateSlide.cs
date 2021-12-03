using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slides
{
    public class CreateSlide
    {
        public string PictureName { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitel { get; set; }
        public string Heading { get; set; }
        public string Titel { get; set; }
        public string Text { get; set; }
        public string BtnText { get; set; }
        public bool IsRemoved { get; set; }
        public string Link { get; set; }
    }
}
