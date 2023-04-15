using PRODUCT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
