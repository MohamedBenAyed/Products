using PRODUCT.BusinessLayer;
using PRODUCT.Entities;
using PRODUCT.Services.Interfaces;
using System.Data;

namespace PRODUCT.Services
{
    public class ProductService : IProductService
    {
        private IGenericBLL<Product> _productBll;

        public ProductService(IGenericBLL<Product> productBll) 
        {
            _productBll = productBll;
        }

        public List<Product> GetProducts()
        {
            return _productBll.GetMany().ToList();
        }
    }
}