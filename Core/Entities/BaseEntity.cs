using System;

namespace Core.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        
        // [ForeignKey("CustomerId")]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // [ForeignKey("CustomerId")]
        public string UpdatedBy { get; set; }
    }
}