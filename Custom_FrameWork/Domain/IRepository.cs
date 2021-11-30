using Custom_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Custom_FrameWork.Domain
{

    /// <summary>
    /// Generic Repository for Curd Operation 
    /// </summary>
    /// <typeparam name="TEntity">Type that curd will be append to..</typeparam>
    /// <typeparam name="TKey">the Tkey is represent of Id for Entities</typeparam>
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {

        /// <summary>
        /// Get entity by its Id 
        /// </summary>
        /// <param name="Id">key of entity</param>
        /// <returns> an operationresult taht contain the Data Porperty type of TEntity or null if no entity is found </returns>
        OperationResult<TEntity> GetbyId(TKey Id);

        /// <summary>
        /// this method get all the entities of TEntity Type in the databse..
        /// </summary>
        /// <returns>an OperationResult that contains list of Entites type of TEntity </returns>
        OperationResult<List<TEntity>> GetAll();

       /// <summary>
       /// Insert the entity into the database type of TEntity
       /// </summary>
       /// <param name="entity">an object type of TEntity</param>
       /// <returns> an operationresult<returns>
        OperationResult Create(TEntity entity);


        /// <summary>
        /// check for the entity thta is exists in database
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> expression);


        /// <summary>
        /// Saveign the data in the Database
        /// </summary>
        /// <returns>an integer reprensetn of how many entity are saved the database. 0 means no entity is saved and error is occured </returns>
        int SaveChanges();

        /// <summary>
        /// Saveign the data in the Database in Asyncrouns 
        /// </summary>
        /// <returns>an integer reprensetn of how many entity are saved the database. 0 means no entity is saved and error is occured </returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Saveign the data in the Database in Asyncrouns 
        /// </summary>
        /// <param name="cancellationToken"> cancellation token for cancele thhe operatin </param>
        /// <returns>an integer reprensetn of how many entity are saved the database. 0 means no entity is saved and error is occured </returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
