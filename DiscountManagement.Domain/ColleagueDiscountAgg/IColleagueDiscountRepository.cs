using Custom_FrameWork.Domain;
using DiscountManagement.Application.Contract.ColleagueDiscounts;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository:IRepository<ColleagueDiscount,long>
    {
        EidtColleagueDiscount GetDetails(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel);
    } 
}
