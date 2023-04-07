using PRODUCT.DataAccess;
using System.Linq.Expressions;

namespace PRODUCT.BusinessLayer
{
    public class GenericBLL<T> : IGenericBLL<T> where T : class, new()
    {
        IUnitOfWork _unitOfWork;
        IRepository<T> _repo;
        public GenericBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = (IRepository<T>)_unitOfWork.GetRepository<T>();
        }
        public void Add(T entity)
        {
            _repo.Add(entity);
        }

        public void AddHard(T entity)
        {
            _repo.AddHard(entity);
        }

        public void Delete(T entity)
        {
            _repo.Delete(entity);
        }

        public void DeleteHard(T entity)
        {
            _repo.DeleteHard(entity);
        }

        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            _repo.DeleteWhere(predicate);
        }

        public T GetById(params object[] id)
        {
            return _repo.GetById(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            return _repo.GetMany(predicate, includeProperties);
        }

        public void Submit()
        {
            _repo.Submit();
        }

        public void Update(T entity)
        {
            _repo.Update(entity);
        }

        public void UpdateHard(T entity)
        {
            _repo.UpdateHard(entity);
        }

    }
}
