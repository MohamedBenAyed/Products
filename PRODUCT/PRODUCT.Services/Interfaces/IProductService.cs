using PRODUCT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.Services.Interfaces
{
    /// <summary>
    /// Product service
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        List<Product> GetProducts();

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProductById(int id);
    }
}
