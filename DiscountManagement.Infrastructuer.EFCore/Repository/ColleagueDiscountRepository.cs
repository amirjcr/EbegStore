using Custom_FrameWork.Application;
using Custom_FrameWork.Infrastructure;
using DiscountManagement.Application.Contract.ColleagueDiscounts;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.Infrastructuer.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructuer.EFCore.Repository
{
    public class ColleagueDiscountRepository : BaseRepository<ColleagueDiscount, long>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopcotnext;

        public ColleagueDiscountRepository(DiscountContext context,ShopContext shopContext):base(context)
        {
            _context = context;
            _shopcotnext = shopContext;
        }
        public EidtColleagueDiscount GetDetails(long id)
        {
            return _context.ColleagueDiscounts.Select(c=> new EidtColleagueDiscount
            {
                DiscountRate = c.DiscountRate,
                Id = c.Id,
                ProductId =c.ProductId, 
            }).FirstOrDefault(c=>c.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel)
        {
            var products = _shopcotnext.Products.AsQueryable().Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.ColleagueDiscounts.AsQueryable().Select(x => new ColleagueDiscountViewModel
            {
                ProductId = x.ProductId,
                CreationDate = x.CreationDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                Id=x.Id
            });  


            if(searchmodel.ProductId > 0)
                query = query.Where(c=>c.ProductId == searchmodel.ProductId);


            var discount = query.OrderByDescending(c=>c.Id).ToList();

            discount.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId).Name);
            return discount;


        }
    }
}
