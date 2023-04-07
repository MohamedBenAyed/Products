using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DataAccess
{
    public interface IUnitOfWork
    {
        void Commit();
        IRepository GetRepository<T>() where T : class;
    }
}
