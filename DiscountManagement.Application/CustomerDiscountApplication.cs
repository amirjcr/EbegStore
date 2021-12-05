using Custom_FrameWork.Application;
using DiscountManagement.Application.Contract.CustomerDiscounts;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {

        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;

        }
        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operation = new OperationResult();

            if (_customerDiscountRepository.Exists(c => c.DiscountRate == command.DiscountRate && c.ProductId == command.ProductId))
                return operation.OnFailer(ApplicationMessages.RecordDuplicated);


            var customerDiscount = new CustomerDiscount(command.ProductId,
                command.DiscountRate,
                command.StartDate.ToGeorgianDateTime(),
                command.EndDate.ToGeorgianDateTime(),
                 command.Reason);

            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChanges();


            return operation.OnSuccess();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var opration = new OperationResult();
            var discount = _customerDiscountRepository.GetbyId(command.Id);

            if (discount.Data == null)
                return opration.OnFailer(ApplicationMessages.RecordNotFount);
            else if (_customerDiscountRepository.Exists(c => c.DiscountRate == command.DiscountRate && c.ProductId == command.ProductId && c.Id != command.Id))
                return opration.OnFailer(ApplicationMessages.RecordDuplicated);

            discount.Data.Edit(command.ProductId, command.DiscountRate,
                command.StartDate.ToGeorgianDateTime()
                , command.EndDate.ToGeorgianDateTime(), command.Reason);

            _customerDiscountRepository.SaveChanges();

            return opration.OnSuccess();    



        }

        public EditCustomerDiscount GetDetails(long id)
        {
           return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model)
        {
            return _customerDiscountRepository.Search(model);
        }
    }
}
