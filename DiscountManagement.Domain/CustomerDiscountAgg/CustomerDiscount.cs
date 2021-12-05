using Custom_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount : EntityBase
    {
        public CustomerDiscount()
        {

        }
        public CustomerDiscount(long productId,
            int discountrate, DateTime startdate,
            DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountrate;
            StartDate = startdate;
            EndDate = endDate;
            Reason = reason;
        } 

        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }
        public bool IsActive { get; private set; }





        public void Edit(long productId,
                         int discountrate, DateTime startdate,
                         DateTime endDate, string reason)
        {
            ProductId = productId;
            DiscountRate = discountrate;
           StartDate = startdate;
            EndDate = endDate;
            Reason = reason;
        }

    }
}
