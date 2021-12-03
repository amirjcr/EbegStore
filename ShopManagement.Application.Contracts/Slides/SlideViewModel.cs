namespace ShopManagement.Application.Contracts.Slides
{
    public class SlideViewModel
    {
        public string PictureName { get; set; }
        public string Heading { get; set; }
        public string Titel { get; set; }
        public long Id { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }

    }
}
