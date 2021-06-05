using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ProductImage : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        
        public Product Product { get; set; }

        public ProductImageStatus Status { get; set; }
        
        public string Url { get; set; }
    }

    public enum ProductImageStatus
    {
        Remove,
        Using
    }
}