using Microsoft.EntityFrameworkCore.Infrastructure;
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

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        public Product AddNewProduct(Product newProduct)
        {
            _productBll.Add(newProduct);
            return newProduct;
        }

        /// <summary>
        /// Update product by Id
        /// </summary>
        /// <param name="product"></param>
        public bool UpdateProductById(Product product)
        {
            Product productInDB = _productBll.GetById(product.Id);
            productInDB.Price = product.Price;
            productInDB.Description = product.Description;
            productInDB.Name = product.Name;

            try
            {
                _productBll.Update(productInDB);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete product by ID
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteProductById(int id)
        {
            Product product = _productBll.GetById(id);
            
            try
            {
                _productBll.Delete(product);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}