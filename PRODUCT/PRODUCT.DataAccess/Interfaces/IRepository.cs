using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DataAccess
{
    public interface IRepository
    {
        void Submit();
    }

    public interface IRepository<T> : IRepository where T : class
    {
        T GetById(params object[] id);

        /// <summary>
        /// Return list of objects filtred by a predicate and including wanted properties 
        /// </summary>
        /// <param name="predicate"> filter to be applied</param>
        /// <param name="includeProperties">list of properties ti include</param>
        /// <returns>List of objects</returns>

        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        void AddHard(T entity);
        void Update(T entity);
        void Delete(T entity);
        void UpdateHard(T entity);
        void DeleteHard(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);


    }
}
