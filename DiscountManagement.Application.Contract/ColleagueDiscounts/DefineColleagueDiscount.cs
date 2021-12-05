using Custom_FrameWork.Application;
using ShopManagement.Application.Contracts.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.ColleagueDiscounts
{
    public class DefineColleagueDiscount
    {
        [Range(1,100_000,ErrorMessage =ValidationMessages.OutofRange)]
        public long ProductId { get; set; }

        [Range(1,99, ErrorMessage = ValidationMessages.OutofRange)]
        public int DiscountRate { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
 }
