using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PRODUCT.Entities
{
    /// <summary>
    /// Product Entity
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}