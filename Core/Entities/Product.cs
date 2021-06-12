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

        [MaxLength(255)]
        public string Description { get; set; }

        [ForeignKey("ProductTypeId")]
        public string ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
        
        // [Column(TypeName = "decimal(18, 2)")]
        public double OriginalPrice { get; set; }

        public ProductStatus Status { get; set; }
        
        public string CoverImageUrl { get; set; }    // 商品封面

        public ICollection<ProductImage> ProductImages { get; set; }
    }

    public enum ProductStatus
    {
        Remove,
        SoldOut,
        Using
    }
}