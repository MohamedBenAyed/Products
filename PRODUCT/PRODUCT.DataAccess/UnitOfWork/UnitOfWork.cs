using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PRODUCT.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Dictionary<Type, IRepository> _repositories;

        public UnitOfWork(
            
            IRepository<Product> productRepo
            )
        {
            _repositories = _repositories ?? new Dictionary<Type, IRepository>();

            _repositories.Add(typeof(Product), productRepo);
        }


        public IRepository GetRepository<T>() where T : class
        {
            return _repositories[typeof(T)];
        }
        public void Commit()
        {
            _repositories.ToList().ForEach(x => x.Value.Submit());
        }


        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
    }
}
