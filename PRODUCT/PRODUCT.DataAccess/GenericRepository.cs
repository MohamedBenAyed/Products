using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PRODUCT.Context;

namespace PRODUCT.DataAccess
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ProductDBContext _context;

        public GenericRepository(ProductDBContext context)
        {
            _context = context;
        }
        public T GetById(params object[] id)
        {
            return _context.Set<T>().Find(id);
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return predicate == null ? query : query.Where(predicate);
        }
        public virtual void Add(T entity)
        {
            //EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public virtual void AddHard(T entity)
        {
            //EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual void AddHard2(List<T> entity)
        {
            //EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().AddRange(entity);
        }
        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }
        public virtual void UpdateHard(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
        }
        public virtual void DeleteHard(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Submit()
        {
            _context.SaveChanges(true);
        }


    }
}
