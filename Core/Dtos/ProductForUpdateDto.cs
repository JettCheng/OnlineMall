using System.ComponentModel.DataAnnotations;

namespace Core.Dtos
{
    public class ProductForUpdateDto
    {
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        
        public double OriginalPrice { get; set; }
        
        public string Status { get; set; }
    }
}