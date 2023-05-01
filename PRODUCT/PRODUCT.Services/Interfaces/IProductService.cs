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

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        Product AddNewProduct(Product newProduct);

        /// <summary>
        /// Update Product By Id
        /// </summary>
        /// <param name="product"></param>
        bool UpdateProductById(Product product);

        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <param name="id"></param>
        bool DeleteProductById(int id);
    }
}
