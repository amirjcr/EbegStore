using Custom_FrameWork.Application;
using Custom_FrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Custom_FrameWork.Infrastructure
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {

        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public OperationResult Create(TEntity entity)
        {
            var opreationresult = new OperationResult();

            _context.Add(entity);

            var saveresult = this.SaveChanges();

            if (saveresult > 0)
                return opreationresult.OnSuccess();
            else
                return opreationresult.OnFailer(message: "error occured while saveing data sorry please try later or contact with the supporter..");

        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
           return _context.Set<TEntity>().Any(expression);
        }

        public OperationResult<List<TEntity>> GetAll()
        {
            var operationresult = new OperationResult<List<TEntity>>();

            return operationresult.OnSuccess(data: _context.Set<TEntity>().ToList(), message: "All Memebers are reurned sucessfuly..");
        }

        public OperationResult<TEntity> GetbyId(TKey Id)
        {
            var opreationresult = new OperationResult<TEntity>();
            var entity = _context.Find<TEntity>(Id);

            if (entity == null)
                return opreationresult.OnFailer($"هیچ رکوردی با این {Id} در دیتا بیس وجود ندارد");
            else
                return opreationresult.OnSuccess(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
