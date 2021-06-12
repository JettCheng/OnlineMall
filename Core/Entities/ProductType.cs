using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ProductType : BaseEntity
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        
        public int Level { get; set; }

        [ForeignKey("ProductTypeCode")]
        public string ParentId { get; set; }
    }
}