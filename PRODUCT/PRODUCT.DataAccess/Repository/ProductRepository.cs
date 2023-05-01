using PRODUCT.Context;
using PRODUCT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DataAccess.Repository
{
    /// <summary>
    /// Repository Product
    /// </summary>
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ProductDBContext context) : base(context)
        {
        }
    }
}
