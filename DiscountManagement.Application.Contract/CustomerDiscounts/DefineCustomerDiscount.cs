using Custom_FrameWork.Application;
using ShopManagement.Application.Contracts.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscounts
{
    public class DefineCustomerDiscount
    {
        [Range(1, 100_000, ErrorMessage = ValidationMessages.OutofRange)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessages.OutofRange)]
        public int DiscountRate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string StartDate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }


    public class EditCustomerDiscount : DefineCustomerDiscount
    {
        public long Id { get; set; }
    }


    public interface ICustomerDiscountApplication
    {

        OperationResult Define(DefineCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);
        EditCustomerDiscount GetDetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model);
    }

}
