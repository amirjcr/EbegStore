using System;

namespace Custom_FrameWork.Application
{
    public class OperationResult
    {
        public string Message { get; set; }
        public bool IsSuccessed { get; set; }

        public OperationResult()
        {
            IsSuccessed = false;
        }


        public  OperationResult OnSuccess(string message = "عملیات با موفقیت انجام شد")
        {
            Message = message;
            IsSuccessed = true;
            return this;
        }


        public virtual OperationResult OnFailer(string message)
        {
            Message = message ?? "operation is failed";
            IsSuccessed = false;
            return this;
        }
    }

    public class OperationResult<TEntity> : OperationResult
        where TEntity : class
    {
        public TEntity Data { get; set; }

        public OperationResult()
        {
            Data = null;
        }


        public  OperationResult<TEntity> OnSuccess(TEntity data, string message = "عملیات با موفقیت انجام شد")
        {
            Message = message;
            IsSuccessed = true;
            Data = data;
            return this;
        }


        public override OperationResult<TEntity> OnFailer(string message)
        {
            Message = message ?? "operation is failed";
            IsSuccessed = false;
            Data = null;
            return this;
        }


    }
}
