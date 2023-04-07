using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.BusinessLayer
{
    public interface IGenericBLL<T> where T : class, new()
    {
        void Add(T entity);
        void AddHard(T entity);

        void Delete(T entity);
        void DeleteHard(T entity);

        void DeleteWhere(Expression<Func<T, bool>> predicate);

        T GetById(params object[] id);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        void Submit();

        void Update(T entity);
        void UpdateHard(T entity);
    }
}