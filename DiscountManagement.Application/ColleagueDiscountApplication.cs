using Custom_FrameWork.Application;
using DiscountManagement.Application.Contract.ColleagueDiscounts;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _repository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Define(DefineColleagueDiscount command)
        {
            var opertaion = new OperationResult();

            if (_repository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return opertaion.OnFailer(ApplicationMessages.RecordDuplicated);


            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            _repository.Create(colleagueDiscount);
            _repository.SaveChanges();

            return opertaion.OnSuccess();
        }

        public OperationResult Edit(EidtColleagueDiscount command)
        {
            var opertaion = new OperationResult();

            if (_repository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return opertaion.OnFailer(ApplicationMessages.RecordDuplicated);


            var colleagueDiscount = _repository.GetbyId(command.Id);
            if (colleagueDiscount.Data == null)
                return opertaion.OnFailer(ApplicationMessages.RecordNotFount);
            if (_repository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return opertaion.OnFailer(ApplicationMessages.RecordDuplicated);
          
            colleagueDiscount.Data.Edit(command.ProductId,command.DiscountRate);
            _repository.SaveChanges();

            return opertaion.OnSuccess();
        }

        public EidtColleagueDiscount GetDetails(long id)
        {
           return _repository.GetDetails(id);
        }

        public OperationResult Remove(long Id)
        {
            var opertaion = new OperationResult();


            var colleagueDiscount = _repository.GetbyId(Id);
            if (colleagueDiscount.Data == null)
                return opertaion.OnFailer(ApplicationMessages.RecordNotFount);
            colleagueDiscount.Data.Remove();
            _repository.SaveChanges();

            return opertaion.OnSuccess();
        }

        public OperationResult Restore(long Id)
        {
            var opertaion = new OperationResult();


            var colleagueDiscount = _repository.GetbyId(Id);
            if (colleagueDiscount.Data == null)
                return opertaion.OnFailer(ApplicationMessages.RecordNotFount);
            colleagueDiscount.Data.Restore();
            _repository.SaveChanges();

            return opertaion.OnSuccess();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchmodel)
        {
          return _repository.Search(searchmodel);
        }
    }
}
