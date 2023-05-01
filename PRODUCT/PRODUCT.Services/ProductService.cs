using PRODUCT.BusinessLayer;
using PRODUCT.Entities;
using PRODUCT.Services.Interfaces;
using System.Data;

namespace PRODUCT.Services
{
    /// <summary>
    /// Product Service - Business code
    /// </summary>
    public class ProductService : IProductService
    {
        private IGenericBLL<Product> _productBll;

        public ProductService(IGenericBLL<Product> productBll) 
        {
            _productBll = productBll;
        }

        #region Methods
        /// <summary>
        /// Get All products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            return _productBll.GetMany().ToList();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            return _productBll.GetById(id);
        }
        #endregion
    }
}