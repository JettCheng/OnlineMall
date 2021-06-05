using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class ProductForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        
        // [Column(TypeName = "decimal(18, 2)")]
        [Required]
        public double OriginalPrice { get; set; }
        
        // [Range(0.0,5.0)]
        // public double Rate { get; set; }
        
        public ICollection<ProductImageForCreationDto> ProductImages { get; set; }
    }
}