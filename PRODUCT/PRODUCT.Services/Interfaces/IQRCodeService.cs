using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.Services.Interfaces
{
    /// <summary>
    /// QR code Service
    /// </summary>
    public interface IQRCodeService
    {
        /// <summary>
        /// Create QR code
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string CreateQRCode(string text);
    }
}
