using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        
        // [Column(TypeName = "decimal(18, 2)")]
        public double OriginalPrice { get; set; }
        
        // [Range(0.0,5.0)]
        // public double Rate { get; set; }

        public ProductStatus Status { get; set; }
        
        public ICollection<ProductImage> ProductImages { get; set; }
    }

    public enum ProductStatus
    {
        Remove,
        SoldOut,
        Using
    }
}