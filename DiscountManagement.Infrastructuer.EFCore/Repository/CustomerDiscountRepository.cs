using Custom_FrameWork.Infrastructure;
using DiscountManagement.Application.Contract.CustomerDiscounts;
using DiscountManagement.Domain.CustomerDiscountAgg;
using ShopManagement.Infrastructuer.EFCore;
using System;
using Custom_FrameWork.Application;

namespace DiscountManagement.Infrastructuer.EFCore.Repository
{
    public class CustomerDiscountRepository : BaseRepository<CustomerDiscount, long>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _discountContext;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext conetxt,ShopContext shopcontext) : base(conetxt)
        {
            _discountContext = conetxt;
            _shopContext = shopcontext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _discountContext.CustomerDiscounts.Select(s => new EditCustomerDiscount
            {
                StartDate = s.StartDate.ToString(),
                DiscountRate = s.DiscountRate,
                EndDate = s.EndDate.ToString(),
                ProductId = s.ProductId, 
                Reason = s.Reason,
                Id = s.Id
            }).FirstOrDefault(x => x.Id == id);
        }
 
        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model)
        {
            var product = _shopContext.Products.Select(x => new
            {
                x.Name,
                x.Id,
            }).ToList();


            var query = _discountContext.CustomerDiscounts.AsQueryable()
                .Select(x => new CustomerDiscountViewModel
                {
                    Reason = x.Reason,
                    StartDate = x.StartDate.ToFarsi(),
                    DiscountRate = x.DiscountRate,
                    EndDate = x.EndDate.ToFarsi(),
                    Id = x.Id,
                    ProductId = x.ProductId,
                    EndDateEn= x.EndDate,
                    StartDateEn = x.StartDate,
                    CreationDate = x.CreationDate.ToFarsi()
                });

            if (model.ProductId > 0)
                query = query.Where(x => x.ProductId == model.ProductId);
            if (!string.IsNullOrWhiteSpace(model.StartDate))
                query = query.Where(x => x.StartDateEn <= model.StartDate.ToGeorgianDateTime());
            if (!string.IsNullOrWhiteSpace(model.EndDate))
                query = query.Where(x => x.EndDateEn <= model.EndDate.ToGeorgianDateTime());


            var discount = query.OrderByDescending(x => x.Id).ToList();

            discount.ForEach(x => x.ProductName = product.FirstOrDefault(x => x.Id == model.ProductId)?.Name);

            return discount;
        }
    }
}
