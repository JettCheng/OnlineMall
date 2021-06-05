using System.ComponentModel.DataAnnotations;

namespace Application.Parameters
{
    public class ProductParameters
    {
        [Required]
        public string Keyword { get; set; }
        
        
    }
}