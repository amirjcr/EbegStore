namespace DiscountManagement.Application.Contract.CustomerDiscounts
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public string CreationDate { get; set; }


        public DateTime StartDateEn { get; set; }
        public DateTime EndDateEn { get; set; }
    }
}
